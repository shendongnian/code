    class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Human> SubHuman { get; set; }
        public Human(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
