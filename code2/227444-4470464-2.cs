    interface IAnimal
    {
        string Speak();
    }
    
    class Dog : IAnimal
    {
        public virtual string Speak()
        {
            return "Bark!";
        }
    }
    class GoldenRetriever : Dog
    {
        public override string Speak()
        {
            return "I am a golden retriever who says " 
                       + base.Speak();
        }
    }
