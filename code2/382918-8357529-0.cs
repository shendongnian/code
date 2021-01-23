    static class TestClass
    {
        static void Main(string[] args)
        {
            Object o = "Previous value";
            Test(ref o);
            Trace.WriteLine(o);
        }
    
        static public void Test(ref obj)
        {    
            Test2(ref obj);
        }
    
        static public void Test2(ref object s)
        {
            if (s.GetType().Equals(typeof(String)))
            {
                s = "Hello world!";
            }
        }
    }
