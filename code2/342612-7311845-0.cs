    int i = 0;
    using (System.Threading.Timer tmr = new System.Threading.Timer((s) =>
        {
            if (Status != null) Status(this, new StatusEventArgs(i));
            ++i;
        }, null, 1000, 1000))
    {
        WaitHandle.WaitOne(token.WaitHandle, TimeSpan.FromSeconds(10)));
    }
