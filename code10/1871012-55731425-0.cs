    public void Fee()
    {
        var list = new List<string>(); // I want to retrieve this instance in Foo
        Foo(list);
    }
    
    public void Foo<T>(IEnumerable<T> enumerable)
    {
        List<T> list = enumerable as List<T> ?? enumerable.ToList();
        // do stuff with original list 
    }
