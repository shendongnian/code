    int i = 0;
    using (System.Threading.Timer tmr = new System.Threading.Timer((s) =>
        {
            if (Status != null) Status(this, new StatusEventArgs(i));
            ++i;
        }, null, 1000, 1000))
    {
        token.WaitHandle.WaitOne(TimeSpan.FromSeconds(10)));
    }
