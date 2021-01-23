    class Animal
    {
        private string name;
        
        public Animal(string name)
        {
            this.name = name;
        }
        public void SayName()
        {
            // Somehow echo out name
        }
        public string Name
        {
           get { return name; }
        }
    }
    class Dog : Animal
    {
        public Dog(string name) : base(name) { }
        
        public void Bark()
        {
            // Bark!
        }
    }
        
    Dog d = new Dog("Skippy");
    d.SayName();
