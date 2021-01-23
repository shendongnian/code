    public IEnumerable<Class> Filter(IEnumerable<Class> collection)
    {
       return someCondition ? collection : FilterImpl(collection);
    }
    private IEnumerable<Class> FilterImpl(IEnumerable<Class> collection)
    {
        yield return new Class(2);
        yield return new Class(1);
        // etc
    }
