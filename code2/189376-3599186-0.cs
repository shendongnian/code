    public void DoSomething()
    {
        this.item = "sometext";
        var itemCopy = item;
        instance.RegisterInvocation<ITarget>(this, p => p.Add(itemCopy));
        this.item = "anothertext";
        instance.CallRegisteredInvocation();
    }
