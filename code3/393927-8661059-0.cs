    public void Method(object strList)
    {
        List<string> internalStringList = strList as List<string>;
        //this is a save cast the "internalStringList" variable will 
        //be null if the cast fails.
    }
