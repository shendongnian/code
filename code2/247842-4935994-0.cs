    protected override void OnSessionChange(SessionChangeDescription changeDescription)
    {
        if(changeDescription.Reason == SessionChangeReason.ConsoleConnect)
        {
            //use changeDescription.SessionId to find if the logged in user 
            //  to that session is an administrator.
        }
    }
