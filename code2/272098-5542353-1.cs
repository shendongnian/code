    class Animal
    {
        private string name;
        
        public Animal(string name)
        {
            this.name = name;
        }
        
        // Define a generic Animal method
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
        // base(..) calls the base constructor, which in this case
        // is the Animal class
        public Dog(string name) : base(name) { }
        
        // Define a Dog specific method
        public void Bark()
        {
            // Bark!
        }
    }
        
    Dog d = new Dog("Skippy");
    d.SayName();
