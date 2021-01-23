    using System;
    using System.Collections.Generic;
    using System.IO;
    
    using Newtonsoft.Json;
    
    public class EmployeeCollection {
        public List<EmployeeWrapper> Employees { get; set; }
    }
    
    public class EmployeeWrapper {
        public Employee Employee { get; set; }
    }
    
    public class Employee    {
        public string Id { get; set; }
        public string Date_Created { get; set; }
        public List<ExtendedProperty> Extended  { get; set; }
    }
    
    public class ExtendedProperty {
        public Address Address { get; set; }
    }
    
    public class Address
    {
        public string Street1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
    
    class Test
    { 
        static void Main() 
        {
            string json = @"{""employees"":
                [{""employee"":
                    {""id"":""1"",
                     ""date_created"":""2011-06-16T15:03:27Z"",
                     ""extended"":[
                        {""address"":
                        {""street1"":""12345 first st."",
                         ""city"":""Denver"",
                         ""state"":""CO""}}]
                  }}]}";
            
            
            var employees =
                 JsonConvert.DeserializeObject<EmployeeCollection>(json);
            foreach (var employeeWrapper in employees.Employees)
            {
                Employee employee = employeeWrapper.Employee;
                Console.WriteLine("ID: {0}", employee.Id);
                Console.WriteLine("Date created: {0}", employee.Date_Created);
                foreach (var prop in employee.Extended)
                {
                    Console.WriteLine("Extended property:");
                    Address addr = prop.Address;
                    Console.WriteLine("{0} / {1} / {2}", addr.Street1,
                                      addr.City, addr.State);
                }
            }
        }     
    }
