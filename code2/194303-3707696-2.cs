    public delegate void myUIDelegate();
    myButton.Dispatcher.BeginInvoke(
        DispatcherPriority.Normal,
        new myUIDelegate(() => {
           // Any code in this anonymous delegate is UI thread safe
           myButton.Enabled = true;
        }));
