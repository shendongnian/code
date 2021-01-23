    void Main()
    {
        MyMethod<B, C>();
    }
    
    public class A {}
    public class B: A {}
    public class C: A {}
    
    public IList<A> MyMethod<T1, T2>()
        where T1 : A, new()
        where T2 : A, new()
    {
        var result = new List<A>();
    
        //add some items to result
        result.Add(new T1() as A);
        result.Add(new T2() as A);
    
        return result;
    }
