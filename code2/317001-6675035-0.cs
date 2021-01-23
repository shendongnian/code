    public IEnumerable<T> Filter(IEnumerable<T> collection)
    {
       if (someCondition)
       {
           return collection
       }
       return new [] {new T()};
    }
