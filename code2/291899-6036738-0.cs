    void Main()
    {
        var i = new Test<int>();
        var s = new Test<string>();
        
        Test<bool>.UsageCount.Dump();
        Test<int>.UsageCount.Dump();
        Test<string>.UsageCount.Dump();
    }
    
    public class Test<T>
    {
        public static int UsageCount;
        
        public Test()
        {
            UsageCount++;
        }
    }
