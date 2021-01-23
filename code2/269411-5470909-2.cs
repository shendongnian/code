    void Main()
    {
        Action a = Test;
        Action b = Test;
        
        (a == b).Dump("==");
        (a.Equals(b)).Dump("Equals");
        object.ReferenceEquals(a, b).Dump("ReferenceEquals");
    }
    
    private static void Test()
    {
    }
