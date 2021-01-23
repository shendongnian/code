     HttpContext ctx = HttpContext.Current;
     Thread t = new Thread(new ThreadStart(() =>
                    {
                        HttpContext.Current = ctx;
                        worker.DoWork();
                    }));
     t.Start();
     // [... do other job ...]
     t.Join();
