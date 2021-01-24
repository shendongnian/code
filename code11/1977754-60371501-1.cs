    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                Employee.ReadFile(FILENAME);
                foreach (Employee employee in Employee.employees)
                {
                    Employee.Print(employee);
                }
                Console.ReadLine();
            }
        }
        public class Employee
        {
            public static List<Employee> employees { get; set; }
            public string name { get; set; }
            public int age { get; set; }
            public string salary { get; set; }
            enum State
            {
                PERSONAL,
                SALARY,
                NONE
            }
            public static void ReadFile(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                string line = "";
                State state = State.NONE;
                Employee employee = null;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        if (line.StartsWith("["))
                        {
                            line = line.Replace("[", string.Empty);
                            line = line.Replace("]", string.Empty);
                            if (line.ToUpper().StartsWith("END"))
                            {
                                state = State.NONE;
                                if(line != "End Employee Personal")
                                    employee = null;
                            }
                            else
                            {
                                switch (line)
                                {
                                    case "Employee Personal":
                                        state = State.PERSONAL;
                                        employee = new Employee();
                                        if (employees == null) employees = new List<Employee>();
                                        employees.Add(employee);
                                        break;
                                    case "Employee salary":
                                        state = State.SALARY;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            if(line.Contains(":"))
                            {
                                string[] properties = line.Split(new char[] { ':' }).ToArray();
                                switch (state)
                                {
                                    case State.PERSONAL :
                                        switch (properties[0].Trim())
                                        {
                                            case "Name" :
                                                employee.name = properties[1].Trim();
                                                break;
                                            case "Age" :
                                                employee.age = int.Parse(properties[1]);
                                                break;
                                        }
                                        break;
                                    case State.SALARY :
                                        employee.salary = properties[1].Trim();
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            public static void Print(Employee employee)
            {
                Console.WriteLine("Name : '{0}', Age : '{1}', Salary : '{2}'", employee.name, employee.age, employee.salary);
            }
        }
    }
