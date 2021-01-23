    public Object getObject(int objType)
    {
        var mapping = new Dictionary<int, Type>()
        {
            { 1, typeof(A) },
            { 2, typeof(B) },
        };
        // use reflections to instantiate based on type
        if(!mapping.ContainsKey(objType))
            throw new ArgumentException("Invalid type ID specified", "objType");
        System.Activator.CreateInstance(mapping[objType]);
    }
