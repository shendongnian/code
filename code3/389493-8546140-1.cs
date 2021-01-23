    [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
    public override void Commit(IDictionary savedState)
    {
        base.Commit(savedState);
        //run the sql script here
    }
