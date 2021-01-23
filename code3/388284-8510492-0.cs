    public class CommonObject
    {
        public string Name;
        public string Signature;
        public string Checksum;
    }
    
    public class X : CommonObject
    {
        // other properties
    }
    
    public class Y : CommonObject
    {
        // other properties
    }
    
    public class Z : CommonObject
    {
        // other properties
    }
    
    public static void DoSomething(CommonObject o)
    {
        // You can access these values
        if (o.Name == "" || o.Signature == "")
            o.Checksum = 0;
    }
