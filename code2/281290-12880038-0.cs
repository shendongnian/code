    public class A {}
    public class B: A {}
    
    public IList<A> MyMethod()
    {
        var result = new List<A>();
    
        //add some items to result
        result.Add(new B());
    
        return result;
    }
