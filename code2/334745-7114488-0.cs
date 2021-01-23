    class Animal
    {
        public Animal() { Name = "animal";  }
        public List<Animal> IfIs<T>()
        {
            if(this is T)
                return new List<Animal>{this};
            else
                return new List<Animal>();
        }
        public string Name;
    }
    class Dog : Animal
    {
        public Dog() { Name = "dog";  }
        public string Bark { get { return "ruff"; } }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var animal = new Animal();
            foreach(Dog dog in animal.IfIs<Dog>())
            {
                Console.WriteLine(dog.Name);
                Console.WriteLine(dog.Bark);
            }
            Console.ReadLine();
        }
    }
