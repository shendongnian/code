    public ViewModel2()
    {
        Messenger.Default.Register<MessageClassName>(this, (message) =>
        {
             ReceiveProperty(message.MyProperty);
        )};
    }
