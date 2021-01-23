        static void Main(string[] args)
        {
            var e = new UsingReleasable<string>("test");
            System.Console.WriteLine("attach now");
            System.Console.ReadLine();
            e.Release();
            System.Console.WriteLine("Value is {0}", e.Value.Length);
        }
