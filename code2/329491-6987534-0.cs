    class Program
    {
        static void Main(string[] args)
        {
            var c = new System.Collections.Concurrent.BlockingCollection<Tuple<bool, Action>>();
            var t = new Thread(() =>
            {
                while (true)
                {
                    var item = c.Take();
                    if (!item.Item1) break;
                    item.Item2();
                }
                Console.WriteLine("Exiting thread");
            });
            t.Start();
            
            Console.WriteLine("Press any key to queue first action");
            Console.ReadKey();
            c.Add(Tuple.Create<bool, Action>(true, () => Console.WriteLine("Executing first action")));
                        
            Console.WriteLine("Press any key to queue second action");
            Console.ReadKey();
            c.Add(Tuple.Create<bool, Action>(true, () => Console.WriteLine("Executing second action")));
            Console.WriteLine("Press any key to stop the thread");
            Console.ReadKey();
            c.Add(Tuple.Create<bool, Action>(false, null));
           
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
