    interface IA 
    {
        void Test();
    }
    interface IB
    {
        void Test();
    }
    class Sample: IA, IB
    {
        public void IA.Test()
        {
          Console.WriteLine("Hi from IA");
        }
        public void IB.Test()
        {
          Console.WriteLine("Hi from IB");
        }
        public void Test() //default implementation would be IA now
        {
          (IA(this)).Test();
        }
    }
