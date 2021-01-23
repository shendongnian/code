    if (ActiveControl.GetType() == typeof(SplitContainer))
    {
        var containerControl = (SplitContainer)ActiveControl;
        if (containerControl.ActiveControl is MemoEdit)
        {
             //Do something
        }
    }
