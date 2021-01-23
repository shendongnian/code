        Data d = new Data();
        d.OnSave += delegate { Console.WriteLine("event"); };
        var handler = typeof(Data).GetField("OnSave", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(d) as Delegate;
        var subscribers = handler.GetInvocationList();
        if (subscribers.Length == 0)
        {
            //no subscribers
        }
        else
        {
            foreach (var s in subscribers)
            {
                s.DynamicInvoke(null, null);
            }
        }
