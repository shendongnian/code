    var waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, "0597f0b8-4472-4e60-b56f-bb44c4ded684", out var createdNew);
        private void StartThread(Action action, int timeout, EventWaitHandle waitHandle)
        {
            new Thread(() =>
            {
                var signaled = false;
                do
                {
                    //Your code
                    // Wait until someone tells us to stop or do something else
                    signaled = waitHandle.WaitOne(TimeSpan.FromMilliseconds(timeout));
                } while (!signaled);
            })
            {
                IsBackground = true
            }.Start();
        }
