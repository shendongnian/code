    public void SomeMethod(object obj1, object obj2, object obj3)
    {
        ArgumentHelper.VerifyNotNull(obj1, obj2, obj3);
        // if we get here we are good!
    }
