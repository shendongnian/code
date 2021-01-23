    using System;
    using System.Collections.Generic;
    
    namespace GenericDictionary
    {
        class Program
        {
            static void Main(string[] args)
            {
                Employee employee = new Employee("Employee", null);
                Employee manager = new Employee("Manager", employee);
                Employee CEO = new Employee("CEO", manager);
                CEO.AddReportee(new Employee("Manager2", employee));
                
                // Uncomment this line to see exception in action
                // employee.AddReportee(CEO);
                try
                {
                    CEO.DisplayReportees();
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("***** Exception: " + ex.Message + " *****");
                }
    
                Console.ReadLine();
            }
    
            public class Employee
            {
                public List<Employee> Reportees { get; private set; }
                public string Name { get; private set; }
                public Employee(string name, Employee reportee)
                {
                    this.Reportees = new List<Employee>();
                    this.Name = name;
                    this.Reportees.Add(reportee);
                }
                public void AddReportee(Employee reportee)
                {
                    Reportees.Add(reportee);
                }
                int indentationCount = 0;
                List<Employee> traversedNodes = new List<Employee>();
                void DisplayReportees(Employee employee)
                {
                    traversedNodes.Add(employee);
                    for (int i = 0; i < indentationCount; i++)
                        Console.Write(" ");
                    Console.WriteLine(employee.Name);
                    indentationCount = indentationCount + 3;
    
                    foreach (Employee reportee in employee.Reportees)
                    {
                        if (AlreadyTraversed(reportee))
                            throw new InvalidOperationException("Circular graph at node " + reportee.Name);
                        if (reportee != null)
                            DisplayReportees(reportee);
                    }
                    indentationCount = indentationCount - 3;
                    traversedNodes.Remove(employee);
                }
    
                bool AlreadyTraversed(Employee employee)
                {
                    return traversedNodes.Contains(employee);
                }
    
                public void DisplayReportees()
                {
                    DisplayReportees(this);
                }
            }
        }
    }
