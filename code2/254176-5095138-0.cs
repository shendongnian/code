    private int MethodToTest() {...}
    
    #if DEBUG
    public int MethodTested()
    {
       return MethodToTest();
    }
    #endif
