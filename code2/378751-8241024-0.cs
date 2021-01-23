    public List<object> Foo(IEnumerable<object> objects)
    {
        if (objects == null)
            throw new ArgumentNullException("objects");
    
        var first = objects.FirstOrDefault();
    
        if (first == null)
            throw new ArgumentException(
                "Empty enumerable not supported.", 
                "objects");
    
        var list = DoSomeThing(first);  
    
        var secondList = DoSomeThingElse(objects);
    
        list.AddRange(secondList);
    
        return list;
    }
