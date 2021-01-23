    public void IHaveNoControlOverWhereThisMethodIsCalled(object arg)
    {
        if(arg == null)
            throw new ArgumentNullException("arg");    
    }
    
    private void TheOnlyCallersOfThisMethodComeFromMe(object arg)
    {
        //I should do all my public parameter checking upstream and throw errors
        //at the public entry point only.
        if(arg == null)
             return;
    
    }
