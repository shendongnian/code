     static void Main(string[] args)
        {
            Class1 c = new Class1();
            string finalResult = "";
            c.AnEvent += (o, entry) => { finalResult = entry; };
            Stopwatch sw = new Stopwatch();
            DateTime start = DateTime.Now;
            while (finalResult == "")
            {
                sw.Start();
                Thread.Sleep(1300);
                var ms = sw.ElapsedMilliseconds;
                Console.WriteLine(ms);
                c.SendMessage("message");
            }
            DateTime end = DateTime.Now;
            Console.WriteLine((end - start).TotalMilliseconds);
    }
