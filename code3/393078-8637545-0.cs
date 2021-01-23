    //This will run two operation in sequence.   
    public class TestThread
    {
        public object obj = new object();
        public void PrintName()
        {
            Monitor.Enter(obj);
            for (int i = 1; i <= 50; i++)
            {
                Console.WriteLine("Name {0}", i);
            }
            Monitor.Exit(obj);
        }
    
        public void PrintType()
        {
            Monitor.Enter(obj);
            for (int i = 100; i <= 180; i++)
            {
                Console.WriteLine("Type {0}", i);
            }
            Monitor.Exit(obj);
        }
    }
