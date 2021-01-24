    public async Task Method1Async()
    {
        Task t1 = browser.EvaluateScriptAsync(myScript1);
        Task t2 = browser.EvaluateScriptAsync(myScript2);
        await t1;
        // Put here the code inside the ContinueWith(x => { ... });
        await t2;
        // Put here the code inside the ContinueWith(x => { ... });
    }
    static void Main()
    {
        Method1Async().Wait();
        // Code which necessitates the information brought by Method1Async.
    }
