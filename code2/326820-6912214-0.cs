    private class Cat
    {
        // Auto-implemented properties.
        public int Age { get; set; }
        public string Name { get; set; }
        public List<Cat> Kittens { get; set; }
    }
    Cat cat = new Cat { Age = 10, Name = "Fluffy" }; //borrowed fluffy for this example
    cat.Kittens = new List<Cat>();
    cat.Kittens.Add( new Cat() { Age = 0, Name = "Pinky" } );
    cat.Kittens.Add( new Cat() { Age = 0, Name = "Blinky" } );
