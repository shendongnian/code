    public abstract class Animal
    {
        public string Name { get;  }
        protected Animal(string name) { Name = name; }
    }
    public class Elephant :  Animal
    {
        public Elephant(string name) : base(name){}
    }
    public class Zebra : Animal
    {
        public Zebra(string name)  : base(name) { }
    }
