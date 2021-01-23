    void Main()
    {
    	
    	
    	int k = 0;
    	TestPlain(k);
    	Console.WriteLine("TestPlain:" + k);
    	
    	TestRef(ref k);
    	Console.WriteLine("TestRef:" + k);
    	
    	string t = "test";
    	
    	TestObjPlain(t);
    	Console.WriteLine("TestObjPlain:" +t);
    	
    	TestObjRef(ref t);
    	Console.WriteLine("TestObjRef:" + t);
    }
    
    public static void TestRef(ref int i)
    {
    	i = 5;
    }
    
    public  static void TestPlain(int i)
    {
    	i = 5;
    }
    
    public static void TestObjRef(ref string s)
    {
    	s = "TestObjRef";
    }
    
    public static void TestObjPlain(string s)
    {
    	s = "TestObjPlain";
    }
