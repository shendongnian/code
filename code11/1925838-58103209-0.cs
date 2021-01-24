    public Dictionary<string, object> GetProgress(int id)
    {
        Dictionary<string, object> returnValue;
        if(obj1)
        {
            Dictionary<string, object1> progresses = new Dictionary<string, object1>();
        }
        else if(obj2)
        {
            Dictionary<string, object2> progresses = new Dictionary<string, object2>();
        }
        return progresses;
    }
Though that might fail as well as you can't implicitly convert a Dictionary of String, Object into a Dictionary of String, "Object1", whatever that is...
