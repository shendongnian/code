    static void DoOperationsAsyncOld()
    {
        Task op1 = new Task(DoOperation1Async);
        op1.ContinueWith(t1 =>
        {
            Task op2 = new Task(DoOperation2Async);
            op2.ContinueWith(t2 =>
            {
                Task op3 = new Task(DoOperation3Async);
                op3.ContinueWith(t3 =>
                {
                    DoQuickOperation();
                }
                op3.Start();
            }
            op2.Start();
        }
        op1.Start();
    }
    static async void DoOperationsAsyncNew()
    {
        await DoOperation1Async();
        await DoOperation2Async();
        await DoOperation3Async();
        DoQuickOperation();
    }
