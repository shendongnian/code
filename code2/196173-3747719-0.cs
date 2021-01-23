    abstract class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("I'm an animal.");
        }
    }
    
    class Dog : Animal
    {
        public override void Speak()
        {
            base.Speak();
            Console.WriteLine("I'm a dog.");
        }
    }
