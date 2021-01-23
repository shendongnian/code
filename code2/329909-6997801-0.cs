            using (var task = Task.Factory.StartNew(() => { }))
            {
                var t = task;
                for (int i = 0; i < 10; ++i)
                {
                   t = t.ContinueWith(_ => increment());
                    // Thread.Sleep(20);  // Uncomment to print 10 instead of 0.
                }
                t.Wait();
            }
