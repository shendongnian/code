            else
            {
                if (number == -99)
                {
                    Console.WriteLine("Consumer thread exit");
                    return;
                }
                Monitor.Exit(locker);
                _wh.WaitOne();         // No more tasks - wait for a signal
            }
 
