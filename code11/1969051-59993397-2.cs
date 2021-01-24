    public class Person
    {
        public Person() { }
        public Person(Person person) { Name = person.Name; City = person.City; }
        public string Name { get; set; }
        public string City { get; set; }
    }
