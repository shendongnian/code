    private static void SimpleLockTest()
            {
                Task[] myTasks = new Task[2];
                myTasks[0] = Task.Factory.StartNew(() =>
                {
                    LockTestThreadOne();
                });
                myTasks[1] = Task.Factory.StartNew(() =>
                {
                    LockTestThreadTwo();
                });
                Task.WaitAll(myTasks);
                Console.WriteLine("Done, press ENTER to quit");
                Console.ReadLine();
            }
    
            private static object locker = new object();
            private static void LockTestThreadOne()
            {
                Monitor.Enter(locker);
                for (int i = 1; i <= 50; i++)
                {
                    Console.WriteLine("Name {0}", i);
                    Monitor.Pulse(locker);
                    Monitor.Wait(locker);                    
                }
                Monitor.Exit(locker);            
            }
    
            private static void LockTestThreadTwo()
            {
                Monitor.Enter(locker);
                for (int i = 100; i <= 180; i++)
                {
                    Console.WriteLine("Type {0}", i);
                    Monitor.Pulse(locker);
                    Monitor.Wait(locker, 10);                    
                }
                Monitor.Exit(locker);
            }
