    class Animal
    {
        abstract Work();
    }
    
    class Cat : Animal
    {
        public Name;
        public Speak();
        override Work()
        {
            Speak();
            Write Name;
        }
    }
    class Person: Animal
    {
        public Title;
        public Name;
        public Speak();
        override Work()
        {
            Speak();
            Write Title;
            Write Name;
        }
    }
    foreach (Animal item in animals)
    {
        item.Work();
    }
