    public class Test
    {
        static Test()
        {
            Task.Factory.StartNew(() =>
            {
                Random r = new Random();
                try
                {
                    while (true)
                    {
                        object o = col.Take();
                        //process o fails at some point
                        if (r.Next(100) == 0)
                        {
                            Console.WriteLine("Fail! No one is processing anymore.");
                            throw new Exception();
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("We caught the exception, but didn't resume processing");
                }
            });
        }
        private static BlockingCollection<object> col = new BlockingCollection<object>();
        public void Add(object o)
        {
            col.Add(o);
        }
    }
    class Program {
        public static void Main(string[] args)
        {
            Test t = new Test();
            while (true)
                t.Add(new object());
        }
    }
