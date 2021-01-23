    void Main()
    {
        var i = new Test1();
        var s = new Test2();
        
        Test1.UsageCount.Dump();
        Test2.UsageCount.Dump();
        Test3.UsageCount.Dump();
    }
    
    public abstract class Base<T>
    {
        public static int UsageCount;
        
        protected Base()
        {
            UsageCount++;
        }
    }
    
    public class Test1 : Base<Test1>
    {
    }
    
    public class Test2 : Base<Test2>
    {
    }
    
    public class Test3 : Base<Test3>
    {
    }
