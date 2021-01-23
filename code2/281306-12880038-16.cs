    void Main()
    {
        MyMethod<A, B, C>();
    }
    
    public class A {}
    public class B: A {}
    public class C: A {}
    
    public IList<TA> MyMethod<TA, TB, TC>()
        where TB : TA, new()
        where TC : TA, new()
        where TA : class
    {
        var result = new List<TA>();
    
        //add some items to result
        result.Add(new B() as TA);
        result.Add(new C() as TA);
    
        return result;
    }
