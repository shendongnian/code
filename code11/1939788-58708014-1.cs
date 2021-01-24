    public string SayHello()
    {
        OperationContext oc = OperationContext.Current;
        var username1=oc.ServiceSecurityContext.PrimaryIdentity.Name;
        Console.WriteLine(username1);
        var username2 = ServiceSecurityContext.Current.PrimaryIdentity.Name;
        Console.WriteLine(username2);
        return $"Hello Buddy,{DateTime.Now.ToLongTimeString()}";
    }
