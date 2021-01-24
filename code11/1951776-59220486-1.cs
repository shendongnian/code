        class Program
        {
            static ManualResetEventSlim mres = new ManualResetEventSlim(false);
            static int x = 89;
            static Thread p0 = new Thread(P0);
            static Thread p1 = new Thread(P1);
            static void P0()
            {
                Interlocked.Increment(ref x);
                Console.WriteLine(x);
            }
            static void P1()
            {
                while(true)
                {
                    if (p0.ThreadState == ThreadState.Unstarted)
                        mres.Wait();
                    else
                        break;
                }
                p0.Join(); 
                Interlocked.Decrement(ref x);
                Console.WriteLine(x);
            }
            static void Main(string[] args)
            {
                p1.Start();
                p0.Start();
                
                mres.Set(); // This will "kick off" the mres spinning inside P1
                mres.Dispose();
                Console.ReadKey();
            }
        }
