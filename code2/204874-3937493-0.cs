            var wsResult = 0;
            Func<int> callWebService = () => {
                Console.WriteLine("1 at " + Thread.CurrentThread.ManagedThreadId);
                return 5;
            };
            var wsAsyncResult = callWebService.BeginInvoke(res => {
                Console.WriteLine("2 at " + Thread.CurrentThread.ManagedThreadId);
                wsResult = callWebService.EndInvoke(res);
            }, null);
            wsAsyncResult.AsyncWaitHandle.WaitOne();
            Console.WriteLine("3 at " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
            Console.WriteLine("Res1 " + wsResult);
            Thread.Sleep(1000);
            Console.WriteLine("Res2 " + wsResult);
