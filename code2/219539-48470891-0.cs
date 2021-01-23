    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var person1 = new Person
            {
                Name = "John",
                Surname = "Doe",
                Age = 47
            };
            var props = typeof(Person).GetProperties();
            int counter = 0;
            while (counter != props.Count())
            {
                Console.WriteLine(props.ElementAt(counter).GetValue(person1, null));
                counter++;
            }
        }
    }
