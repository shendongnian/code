    protected override void OnSessionChange(SessionChangeDescription changeDescription)
    {
        if (changeDescription.Reason == SessionChangeReason.SessionLogoff)
            //your code here
        base.OnSessionChange(changeDescription);
    }
