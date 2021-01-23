    public class MyEventGen
    {
        public event Action ReceiveDataArray;
    }
    
    class Program
    {
        public static void Main()
        {
            var gen = new MyEventGen();
            var wr = new WeakReference(gen);
            // this is the last time we access the 
            // gen instance in this scope so after this line it
            // is eligible for garbage collection
            gen.ReceiveDataArray += new Action(gen_ReceiveDataArray);
            // run the collector
            GC.Collect();
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine(wr.IsAlive);
            }
        }
    
        static void gen_ReceiveDataArray()
        {
        }
    }
