            TimeSpan stop;
            TimeSpan start = new TimeSpan(DateTime.Now.Ticks);
            for (int i = 0; i < 10000; i++)
            {
                 MainMethod(1, null);
            }
            
            stop = new TimeSpan(DateTime.Now.Ticks);
            TimeSpan stop2;
            TimeSpan start2 = new TimeSpan(DateTime.Now.Ticks);
            for (int i = 0; i < 10000; i++)
            {
                MainMethod(1);
            }
            stop2 = new TimeSpan(DateTime.Now.Ticks);
            Console.WriteLine(stop.Subtract(start).TotalMilliseconds);
            Console.WriteLine(stop2.Subtract(start2).TotalMilliseconds);
            public static void MainMethod(int id, MyClass model = null)
            {
                if (model == null)
                {
                    Console.WriteLine("Is null");
                }
                else
                {
                    Console.WriteLine("Is Not null");
                }
            }
