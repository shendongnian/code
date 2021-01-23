    private void MyMethod()
    {
        static string testString = "Hello";
        Action<object, EventArgs> clickAction = (object sender, EventArgs e) =>
        {
            MessageBox.Show(testString);
        };
    
        Type buttonType = button1.GetType();
        EventInfo clickEvent = buttonType.GetEvent("Click");
        Delegate clickEventHandler = Delegate.CreateDelegate(clickEvent.EventHandlerType,
                                                             null,
                                                             clickAction.Method);
        clickEvent.AddEventHandler(button1, clickEventHandler);
    }
