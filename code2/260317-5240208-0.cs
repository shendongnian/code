    public class Person
    {
        public string Name {get; private set;}
        public Person(string name)
        {  Name = name; }
    }
    public class Employee : Person
    {
        public DateTime HireDate {get; private set;}
        public Employee(string name, DateTime hireDate)
            : base (name)
        {    HireDate = hireDate;  }
    }
