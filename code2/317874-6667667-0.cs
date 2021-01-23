    public bool SomeMethod(object item)
    {
        var something = item as SomeClass;
        if (something != null)
        {
            return something.IsActive;
        }
        else
        {
            return somethingElse;
        }
    }
   
