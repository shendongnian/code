    private uint _counter = 0;
    public YourMethod()
    {
        if (ip == StrIp)
        {
            Action<Task> action = _ =>
            {
                var res = from i in dc.Pins //LINQ Query
                          where i.ip == ip
                          select i;
                //...
                datacontext.submitChanges();
            };
            if (_counter++ == 0)
                action();
            else
                Task.Delay(300000).ContinueWith(action);
        }
    }
