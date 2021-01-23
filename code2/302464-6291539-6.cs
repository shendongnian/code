        Data d = new Data();
        d.OnSave += delegate { Console.WriteLine("event"); };
        var handler = typeof(Data).GetField("OnSave", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(d) as Delegate;
        if (handler == null)
        {
            //no subscribers
        }
        else
        {
            var subscribers = handler.GetInvocationList();
            //now you have the subscribers
        }
