        abstract class Animal
        {
            public abstract void Speak() { }
        }
    
        public class Dog : Animal
        {
            public override void Speak()
            {
                Console.WriteLine("Woof");
            }
        }
