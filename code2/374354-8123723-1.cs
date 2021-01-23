    using System;
    using Newtonsoft.Json;
    
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var json = "{name: 'John', age: 15}";
            var customer = JsonConvert.DeserializeObject<Customer>(json);
            Console.WriteLine("name: {0}, age: {1}", customer.Name, customer.Age);
        }
    }
