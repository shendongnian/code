    class Human
    {
        public int Age { get; set; }
    }
    IEnumerable<Human> people = ...
    int age = people.Average(p => p.Age);
