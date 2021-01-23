    static void Main(string[] args)
    {
        AutoResetEvent are = new AutoResetEvent(false);
        Form f = new Form();
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        new Thread(
            () =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                var nw = NativeWindow.FromHandle(f.Handle);
                are.Set();
                Application.Run(f);
            }).Start();
        are.WaitOne(new TimeSpan(0, 0, 2));
        f.Invoke(
            (Action)(() =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            }), null);
        Console.ReadLine();
    }
