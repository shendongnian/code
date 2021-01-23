    abstract class Animal
    {
        public void Speak()
        {
            Console.WriteLine("I'm an animal.");
            DoSpeak();
        }
    
        protected abstract void DoSpeak();
    }
    
    class Dog : Animal
    {
        protected override void DoSpeak()
        {
            Console.WriteLine("I'm a dog.");
        }
    }
