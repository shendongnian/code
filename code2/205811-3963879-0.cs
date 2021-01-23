    public class Person
    {
        public string Name { get; protected set; }
        public int Age { get; protected set; }
    }
    public class PersonRepository
    {
        public Person Get()
        {
            return new PersonBuilder("TestName", 25);
        }
        private class PersonBuilder : Person
        {
            public PersonBuilder(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
        }
    }
