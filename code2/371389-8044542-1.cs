    public bool ExistsUnique(Func<T, bool> p)
    {
        try
        {
            var temp = myCollection.Single(x => p(x));
        }
        catch(Exception e)
        {
            // log exception
            return false;
        }
        return true;
    }
