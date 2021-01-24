        interface IA<T> where T : class
    {
        T Format { get; }
        void Print();
    }
    abstract class A<T> : IA<T> where T : class
    {
        protected bool isFormated;
        public T Format
        {
            get
            {
                isFormated = true;
                return this as T;
            }
        }
        virtual public void Print()
        {
            Console.WriteLine("this is A");
        }
    }
    interface IB
    {
        void Print();
        void PrintB();
    }
    class B : A<B>, IB
    {
        override public void Print()
        {
            Console.WriteLine("this is B");
        }
        public void PrintB()
        {
            if (isFormated)
            {
                Console.WriteLine("this is formated B");
            }
            else
            {
                Console.WriteLine("this is B");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var x = new B();
            x.Format.PrintB();
        }
    }
