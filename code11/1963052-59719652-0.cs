    //Your class
    public class Foo
    {
        public string Value { get; set; }
    }
    
    //Your method
    private T CreateItem<T>(List<T> poList, string psValue) where T : class, new()
    {
        T loNew = new T();
    
        if (loNew is Foo)
            (loNew as Foo).Value = psValue;
    
        return loNew;
    }
