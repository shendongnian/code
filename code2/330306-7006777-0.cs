    public void RemoveAll(T theValue)
    {
        //  this will work
        InternalList.RemoveAll(x => EqualityComparer<T>.Default.Equals(x, theValue));
    }
