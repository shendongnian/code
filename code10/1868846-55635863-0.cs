    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
    {
        //create myStyle here...
        var myStyle = ...;
        MessageBox.Show("Message Text", ..., myStyle);
    }));
