    protected delegate void OnUiThreadDelegate();
    protected void OnUiThread(OnUiThreadDelegate onUiThreadDelegate)
    {
        if (Deployment.Current.Dispatcher.CheckAccess())
        {
            onUiThreadDelegate();
        }
        else
        {
            Deployment.Current.Dispatcher.BeginInvoke(onUiThreadDelegate);
        }
    }
