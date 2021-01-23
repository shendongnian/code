    class Program
    {
        static void Main(string[] args)
        {
            Func();
            Func();
            Thread.Sleep(6000);
        }
        static void Func()
        {
            Action act = () =>
                    {
                        Thread.Sleep(2000);
                    };
            IAsyncResult actAsyncResult = act.BeginInvoke(a =>
                    {
                        Console.WriteLine("exiting..");
                    }, null);
            Console.WriteLine("Func done...");
            act.EndInvoke(actAsyncResult);
        }
    }
