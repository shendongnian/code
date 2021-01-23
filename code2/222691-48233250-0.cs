            Thread th = null;
            Task.Factory.StartNew(() =>
            {
                th = Thread.CurrentThread;
                
                while (true)
                {
                     Console.WriteLine(DateTime.UtcNow);
                }
            });
            Thread.Sleep(2000);
            th.Abort();
            Console.ReadKey();
