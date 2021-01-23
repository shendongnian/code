    protected override void OnSessionChange(SessionChangeDescription changeDescription)
    {
        if (changeDescription.Reason == SessionChangeReason.SessionLogoff)
        {
            //Your code here...
            //I called a static method in my WCF inbound interface class to do stuff...
        }
    
        //Don't forget to call ServiceBase OnSessionChange()
        base.OnSessionChange(changeDescription);
    }
