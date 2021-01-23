    static void Test(string someParam)
    {
        if (someParam == null) { 
            throw new ArgumentNullException(GetMemberName(() => someParam)); 
        }
    }
    
