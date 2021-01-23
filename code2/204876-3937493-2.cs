            var wsResult = 0;
            Func<int> callWebService = () => {
                Console.WriteLine("1 at " + Thread.CurrentThread.ManagedThreadId);
                return 5;
            };
            var wsAsyncResult = callWebService.BeginInvoke(null, null);
            wsAsyncResult.AsyncWaitHandle.WaitOne();
            wsResult = callWebService.EndInvoke(wsAsyncResult);
