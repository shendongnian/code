    class Weird : IEnumerable<Turtle>, IEnumerable<Banana> { ... }
    class B 
    { 
        public void M(IEnumerable<Banana> bananas) {}
    }
    class D : B
    {
        public void M(IEnumerable<Animal> animals) {}
        public void M(IEnumerable<Fruit> fruits) {}
    }
