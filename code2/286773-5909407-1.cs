    public GenericEqualityComparer(Func<T, object> projection)
    {
    	compareFunction = (t1, t2) => projection(t1).Equals(projection(t2));
    	hashFunction = t => projection(t).GetHashCode();
    }
    
    var comaparer = new GenericEqualityComparer( o => o.PropertyToCompare);
