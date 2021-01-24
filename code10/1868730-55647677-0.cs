    Task.Run(() =>
                 {
                     for (int i = 10; i > 0; i--)
                     {
                         Counter = i;
                         Thread.Sleep(1000);
                     }
                 });
