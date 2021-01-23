    public class Mammal
    {
        public virtual void AnswerWhatAmI()
        {
            Console.WriteLine("I'm a mammal");
        }
    }
    public class Dog:Mammal, IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("arf");
        }
        public void RunToOwnerWhenCalled()
        {
            Console.WriteLine("Comming");
        }
    }
    public class Cat:Mammal, IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("meow");
        }
        public void RunToOwnerWhenCalled()
        {
            Console.WriteLine("I don't know you");
        }
    }
