    public class Person
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
...
    List<Person> people = new List<Person>();
    people.Add(new Person() { Name = "Not Me", Phone = "(555) 212-1234", Address = "123 Fake St." });
    string address = people[0].Address;
