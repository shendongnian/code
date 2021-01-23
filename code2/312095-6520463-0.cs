    public class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("...");
        }
    }
    public class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Bow-wow");
        }
    }
    public class Human : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Hello, how are you?");
        }
    }
