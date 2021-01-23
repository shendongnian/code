    // Checks parameters early. - Fine. The passed argument will be checked directly when
    // GetByReturn() is called.
    IEnumerable<int> GetByReturn(IEnumerable<int> sequence)
    {
    	if(null == sequence)
        {
            throw new ArgumentNullException("sequence");
        }
        return GetIterator();
    }
    // Checks parameters deferred. - Possibly not desired, it's "too" late. I.e. when the    
    // result is iterated somewhere in a completely different location in your code the 
    // argument passed once will be checked.
    IEnumerable<int> GetByReYielding(IEnumerable<int> sequence)
    {
        if(null == sequence)
        {
            throw new ArgumentNullException("sequence");
        }
        for(var item in GetIterator()) 
        {
            yield return item;
        }
    }
