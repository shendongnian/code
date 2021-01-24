csharp
using MongoDB.Entities; //Install-Package MongoDB.Entities
using MongoDB.Entities.Core;
using System;
using System.Linq;
namespace StackOverflow
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public Agent Agent { get; set; }
    }
    public class Agent
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class Program
    {
        private static void Main()
        {
            new DB("test", "localhost");
            // create a customer with embedded agent
            var customer = new Customer
            {
                Name = "Customer A",
                Agent = new Agent { Name = "Agent Uno", Email = "uno@youknow.com" }
            };
            customer.Save();
            // update customer name
            DB.Update<Customer>()
              .Match(c =>
                     c.ID == customer.ID &&
                     c.Agent.Email == "uno@youknow.com")
              .Modify(c =>
                      c.Name, "Updated Customer")
              .Execute();
            // find updated customer
            var cst = DB.Find<Customer>()
                        .Match(customer.ID)
                        .Execute()
                        .Single();
            Console.WriteLine($"Customer Name: {cst.Name}");
            Console.Read();
        }
    }
}
