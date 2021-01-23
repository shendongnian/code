    private void PrivateFoo(IInterfaceA objA, IInterfaceB objB)
    {
        if (!ReferenceEquals(objA, objB))
            throw new ArgumentException("objA and objB must refer to the same object");
        //... do your thing here
    }
    public void Foo(object someObj)
    {
        PrivateFoo((IInterfaceA)someObj, (IInterfaceB)someObj);
    }
