    [WebMethod]
    public void Fnc()
    {
        ...
        ...
        System.Security.Principal.WindowsIdentity wi =    System.Security.Principal.WindowsIdentity.GetCurrent();
        System.Threading.Thread postJobThread = new Thread(PostJobThread);
        postJobThread.Start(wi);
        ...
    }
    
    ...
    
    private void PostJobThread(object ob)
    {
        System.Security.Principal.WindowsIdentity wi = (System.Security.Principal.WindowsIdentity)ob;
        System.Security.Principal.WindowsImpersonationContext ctx = wi.Impersonate();
    
        ...
        // Do some job which couldn't be done in this thread
        ...
        // OK, job is finished
        if(ctx != null)
        ctx.Undo();
    }
