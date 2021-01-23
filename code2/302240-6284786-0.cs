    public class Person
    {
        public string Name {get;set;}
        public int Age {get;set;}
    }
    List<Person> person = new List<Person>();
    Person p = new Person {Name = "John Doe", Age=30};
    person.Add(p);
