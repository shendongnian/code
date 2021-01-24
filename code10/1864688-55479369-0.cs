    abstract class A : IA
    {
        public IA Next()
        {
            return this;
        }
        virtual public void Print()
        {
            Console.WriteLine("this is A");
        }
        public abstract void PrintB();
    }
