    using System;
    using System.Web.Script.Serialization;
    
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var serializer = new JavaScriptSerializer();
            var json = "{name: 'John', age: 15}";
            var customer = serializer.Deserialize<Customer>(json);
            Console.WriteLine("name: {0}, age: {1}", customer.Name, customer.Age);
        }
    }
