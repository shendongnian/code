csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            var employees = new List<Employee>();
            var result = employees.Join(people, x => x.Id, y => y.Id, (x, y) => new JoinedItem{ Id = x.Id, Name = y.Name });
            var result2 = employees.Join<Employee, Person, int, JoinedItem>(people, x => x.Id, y => y.Id, (x, y) => new JoinedItem { Id = x.Id, Name = y.Name });
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class JoinedItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
