    interface IAnimal
    {
        string Speak();
    }
    
    abstract class Dog : IAnimal
    {
        public abstract string Speak();
    }
    
    class GoldenRetriever : Dog
    {
        public override string Speak()
        {
            return "I am a golden retriever";
        }
    }
