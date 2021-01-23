    class Program
    {
        static void Main(string[] args)
        {
            Something something = new Something();
            Foo(something);
            Console.ReadKey(true);
            GC.Collect();
            Console.ReadKey(true);
        }
        private static void Foo(Something something)
        {
            Timer timer = new Timer(new TimerCallback(something.DoIt),null,0,5);
            return;
        }
    }
    public class Something
    {
        public void DoIt(object state)
        {
            Console.WriteLine("foo{0}", DateTime.Now.Ticks);
        }
    }
