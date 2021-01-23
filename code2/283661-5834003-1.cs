        static void Main(string[] args)
        {
            var maxSize = 1000000;
            var items = new List<NonStatic>();
            //var items = new List<Static>();
            for (var i=0;i<maxSize;i++)
            {
                items.Add(new NonStatic());
                //items.Add(new Static());
            }
            Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().WorkingSet64);
            Console.Read();
        }
