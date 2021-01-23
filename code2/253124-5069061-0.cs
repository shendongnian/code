    public class Animal
    {
        public Animal()
        {
            // Don't do this in the constructor
            // Speak();
        }
        public virtual void Speak()
        {
            Console.WriteLine("Animal speak");
        }
    }
    public class Dog : Animal
    {
        private StringBuilder sb = null;
        public Dog()
        {
            sb = new StringBuilder();
        }
        public override void Speak()
        {
            Console.WriteLine("bow...{0}", sb.Append("bow"));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dog d = new Dog();
            d.Speak();
        }
    }
