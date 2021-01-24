    class Program
    {
        static void Main(string[] args)
        {
            // searched data from db
            List<Person> people = new List<Person> { new Person(0, "Ben"), new Person(1, "Maria"), new Person(2, "Liza") };
            // search data
            List<string> nameList = new List<string> { "Liza", "Maria" };
            
            var result = nameList.Join(people, n => n, p => p.Name, (n, p) => p.Id).ToList();
        }
    }
    class Person
    {
        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
