    public void MyMethod(MyClass cannotBeNull)
    {
        if (cannotBeNull == null)
        {
            throw new ArgumentNullException("cannotBeNull");
        }
        // Do something useful
    }
