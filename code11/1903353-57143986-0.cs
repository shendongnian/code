    public void Method1()
    {
        Task t1 = browser.EvaluateScriptAsync(myScript1);
        t1.Wait();
        // Put here the code inside the ContinueWith(x => { ... });
        Task t2 = browser.EvaluateScriptAsync(myScript2)
        t2.Wait();
        // Put here the code inside the ContinueWith(x => { ... });
    }
