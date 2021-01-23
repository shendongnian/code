    using System;
    
    namespace Domain
    {
      public class Person
      {
        public Person()
        {
        }
        public Person(Person person)
        {
          FirstName = person.FirstName;
          LastName = person.LastName;
          BirthDay = person.BirthDay;
        }
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
      }
    }
    using System;
    using Remotion.Mixins;
    
    namespace Domain
    {
      public interface IEmployeeMixin
      {
        int Salary { get; set; }
        DateTime? HireDate { get; set; }
      }
    
      [Extends(typeof(Person))]
      public class EmployeeMixin : IEmployeeMixin
      {
        public int Salary { get; set;  }
        public DateTime? HireDate { get; set;}
        public EmployeeMixin()
        {
          // set default values
          Salary = 1000;
          HireDate = DateTime.Now;
        }
      }
    }
    using Domain;
    using Remotion.Reflection;
    using Remotion.Mixins;
    
    namespace ConsoleApp
    {
      class Program
      {
        static void Main(string[] args)
        {
          Person p = new Person();
          p.FirstName = "John";
          p.LastName = "Doe";
    
          var employee = (IEmployeeMixin)ObjectFactory.Create<Person>(ParamList.Create(p));
    
          System.Console.WriteLine("Fullname: {0}", ((Person)employee).FirstName + " " + ((Person)employee).LastName);
          System.Console.WriteLine("Salary: {0}", employee.Salary);
          
          System.Console.ReadKey();
        }
      }
    }
