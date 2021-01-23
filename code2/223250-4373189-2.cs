    for (var i = 0; i < ListProxies.Items.Count; i++)
     {
        var s = ListProxies.Items[i] as string;
        // Does ProxyTest.IsAlive really represent a method? 
        ThreadPool.QueueUserWorkItem(ProxyTest.IsAlive, s);       
     }
