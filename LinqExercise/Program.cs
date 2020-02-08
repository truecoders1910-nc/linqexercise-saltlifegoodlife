using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine($"sum of numbers is {numbers.Sum()}");
            Console.WriteLine($"average of numbers is {numbers.Average()}");
            Console.WriteLine("--------------------------");
            //Order numbers in ascending order and decsending order. Print each to console.
            var decendList = numbers.OrderByDescending(num => num).ToList();
            foreach (var n in decendList)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("--------------------------");
            var ascendList = numbers.OrderBy(num => num);
            foreach (var n in ascendList)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("--------------------------");
            //Print to the console only the numbers greater than 6
            var greater = numbers.Where(num => num > 6).ToList();
            Console.WriteLine("greater than 6:");
            foreach ( int n in greater)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("--------------------------");
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var takeFour = numbers.OrderBy(x => x).Take(4);
            Console.WriteLine("Only four:");
            foreach (var item in takeFour)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------------");
            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers.SetValue(30, 4);
            var newList = numbers.OrderByDescending(x => x);
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("-----------------------");
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var firstName = employees.OrderBy(x => x.FirstName).Where(name => employees.Any(names => name.FirstName.StartsWith("C") || name.FirstName.StartsWith("S")));
            foreach (var item in firstName)
            {
                Console.WriteLine(item.FullName);
            }
            Console.WriteLine("---------------------");
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var age = employees.OrderBy(x => x.Age).OrderBy(x => x.FirstName).Where(name => employees.Any(names => name.Age > 26));
            foreach (var item in age)
            {
                Console.WriteLine($"{item.FullName},{item.Age}");
            }
            Console.WriteLine("----------------------");
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine(employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience));
            Console.WriteLine(employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Average(x => x.YearsOfExperience));
            Console.WriteLine("-----------------------");
            //Add an employee to the end of the list without using employees.Add()
            Employee emp = new Employee("Ross", "Beckham", 30, 5);
            var newEmployees = employees.Append(emp).ToList();
            foreach (var item in newEmployees)
            {
                Console.WriteLine($"{item.FullName},{item.Age},{item.YearsOfExperience}");
            }
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
