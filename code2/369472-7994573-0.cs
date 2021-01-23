    public interface ITest
    {
    }
    
    public class Test1 : ITest
    {
    }
    
    public class Test2 : ITest
    { }
    
    
    static void Main(string[] args)
    {
        List<ITest> list = new List<Test1>();
    
        list.Add(new Test1());
        list.Add(new Test2());
        
    }
