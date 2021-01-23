    public class Zebra : Animal
    {
        public Zebra(string name) : base(name) { }
        public static implicit operator Elephant(Zebra z)
        {
            return new Elephant(z.Name);
        }
    }
