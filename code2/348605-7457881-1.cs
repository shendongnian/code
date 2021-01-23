    //close proxy in callback function
    private void ButtonCallbackClick(object sender, EventArgs e)
    {
        var proxy = new ServiceClient("BasicHttpBinding_IService");
        proxy.BeginDoWork(DateTime.Now.ToShortDateString(), CallBack, proxy);
    }
    private void CallBack(IAsyncResult ar)
    {
        var result = (ar.AsyncState as ServiceClient).EndDoWork(ar);
        if (ar.IsCompleted)
            UpdateView(result);
        CloseProxy(ar.AsyncState);
    }
    //close proxy in event handler
    private void ButtonCompletedClick(object sender, EventArgs e)
    {
        var proxy = new ServiceClient("BasicHttpBinding_IService");
        proxy.DoWorkAsync(DateTime.Now.ToShortDateString());
        proxy.DoWorkCompleted += DoWorkCompleted;
    }
    private void DoWorkCompleted(object sender, DoWorkCompletedEventArgs e)
    {
        if (e.Error == null)
            UpdateView(e.Result);
        CloseProxy(sender);
    }
    private static void CloseProxy(object sender)
    {
        var proxy = sender as ServiceClient;
        if (proxy == null) return;
        try
        {
            proxy.Close();
        }
        catch (CommunicationException e)
        {
            proxy.Abort();
        }
        catch (TimeoutException e)
        {
            proxy.Abort();
        }
        catch (Exception e)
        {
            proxy.Abort();
        }
    }
    private static bool _run = false;
    //run async query in infinite cycle
    private void ButtonCycleClick(object sender, EventArgs e)
    {
        _run = !_run;
        if (!_run) return;
        Action<object> action = WaitEvent;
        ThreadPool.QueueUserWorkItem(a => action(action));
    }
    private void WaitEvent(object action)
    {
        var proxy = new ServiceClient("BasicHttpBinding_IService");
        proxy.DoWorkAsync(DateTime.Now.ToShortDateString());
        proxy.DoWorkCompleted += (x, y) => DoWorkCompleted(x, y, action as Action<object>);
    }
    private void DoWorkCompleted(object sender, DoWorkCompletedEventArgs e, Action<object> action)
    {
        if (!_run)
            return;
        if (e.Error == null)
            UpdateView(e.Result);
        CloseProxy(sender);
        action(action);
    }
