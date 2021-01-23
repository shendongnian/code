    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace LinqSingleorSingleOrDefault
    {
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            IList<Employee> employeeList = new List<Employee>(){
                new Employee() { Id = 10, Name = "Chris", City = "London" },
                new Employee() { Id=11, Name="Robert", City="London"},
                new Employee() { Id=12, Name="Mahesh", City="India"},
                new Employee() { Id=13, Name="Peter", City="US"},
                new Employee() { Id=14, Name="Chris", City="US"}
            };
                 
            //Single Example
            var result1 = employeeList.Single(); 
            // this will throw an InvalidOperationException exception because more than 1 element in employeeList.
            
            var result2 = employeeList.Single(e => e.Id == 11);
            //exactly one element exists for Id=11
            
            var result3 = employeeList.Single(e => e.Name == "Chris");
            // throws an InvalidOperationException exception because of more than 1 element contain for Name=Chris
            
            IList<int> intList = new List<int> { 2 };
            var result4 = intList.Single(); 
            // return 2 as output because exactly 1 element exists
            //SingleOrDefault Example
            
            var result5 = employeeList.SingleOrDefault(e => e.Name == "Mohan");
            //return default null because not element found for specific condition.
            var result6 = employeeList.SingleOrDefault(e => e.Name == "Chris");
            // throws an exception that Sequence contains more than one matching element
            var result7 = employeeList.SingleOrDefault(e => e.Id == 12);
            //return only 1 element
            
            Console.ReadLine();
        }
     }   
    }
