    private void TestMulticastDelegate()
    {
        Func<int, bool> function1 = IntToBool;
        Func<string, bool> function2 = StringToBool;
        Func<int, string, bool> function3 = IntAndStringToBool;
        int intArg = 1;
        string stringArg = "someString";
        MulticastDelegate d;
        d = new Func<int, bool>(IntToBool);
        bool res1 = d.DynamicInvoke(intArg).Equals(function1(intArg)); // always true
        
        d = new Func<string, bool>(StringToBool);
        bool res2 = d.DynamicInvoke(stringArg).Equals(function2(stringArg)); // always true
        
        d = new Func<int, string, bool>(IntAndStringToBool);
        bool res3 = d.DynamicInvoke(intArg, stringArg).Equals(function3(intArg, stringArg)); // always true
    }
    
    private bool IntToBool(int i)
    {
        return i == 0;
    }
    
    private bool StringToBool(string s)
    {
        return string.IsNullOrEmpty(s);
    }
    
    private bool IntAndStringToBool(int i, string s)
    {
        return i.ToString().Equals(s, StringComparison.OrdinalIgnoreCase);
    }
