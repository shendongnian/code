        static void Main(string[] args)
        {
            List<AutoResetEvent> areList = new List<AutoResetEvent>();
            foreach (MyObject o in ListOfMyObjects)
            {
                AutoResetEvent are = new AutoResetEvent(false);
                areList.Add(are);
                ThreadPool.QueueUserWorkItem(DoWork, new { o, are });
            };
            Console.WriteLine("Time: {0}", DateTime.Now);
            WaitHandle.WaitAll(areList.ToArray());
            Console.WriteLine("Time: {0}", DateTime.Now);
            Console.ReadKey();
        }
        static void DoWork(object state)
        {
            dynamic o = state;
            string myObject = (MyObject)o.o;
            AutoResetEvent are = (AutoResetEvent)o.are;
            myObject.Execute();
            are.Set();
        }
