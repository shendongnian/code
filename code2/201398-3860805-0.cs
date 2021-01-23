    class Fail
    {
        static Fail()
        {
        }
    
        Fail()
        {
            throw new System.Exception ("failed");
        }
    
        static readonly Fail instance = new Fail ();
    
        public static void Test()
        {
        }
    }
