    public delegate void myUIDelegate();
    myButton.Dispatcher.BeginInvoke(
        DispatcherPriority.Normal,
        new myUIDelegate(EnableButton));
    ...
    private void EnableButton() {
       myButton.Enabled = true;
    }
