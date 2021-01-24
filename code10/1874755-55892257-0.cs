    using Data;
    using System;
    using System.Collections.Generic;
    
    namespace TestPaths
    {
        public class Customer
        {
            public string Name { get; set; }
            public List<string> Vehicles { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var customers = new List<Customer>();
                Console.WriteLine("Hello World!");
                var inputFile = File.ReadAllLines("Customer.CSV");
                var customer = new Customer
                {
                    Name = inputFile[0], //the first line is the first customer
                    Vehicles = new List<string>()
                }; 
    
                for (int i = 2; i < inputFile.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(inputFile[i]))
                    {
                        customer.Vehicles.Add(inputFile[i]);
                    } else
                    {
                        customers.Add(customer);
                        if(i++<inputFile.Length)
                        customer = new Customer
                        {
                            Name = inputFile[i], //the name is one past the blank
                            Vehicles = new List<string>()
                        };
                        i++; //skip the next blank
                    }
                }
                customers.Add(customer); //add in the last customer
                foreach (var cust in customers)
                {
                    Console.WriteLine(cust.Name);
                }
                Console.ReadLine();
            }
        }
    }
