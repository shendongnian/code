    void Main()
    {
        MyMethod<B>();
    }
    
    public class A {}
    public class B: A {}
    //public class C: A {} //Even if I don't add that class
    
    public IList<T> MyMethod<T>()
        where T : A, new()
    {
        var result = new List<T>();
    
        //add some items to result
        result.Add(new T());
    
        return result;
    }
