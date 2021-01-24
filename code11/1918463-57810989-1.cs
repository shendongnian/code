    class ObjectBase
    {
    	public string Item;
    	public int b;
    }
    
    class ObjectA : ObjectBase
    {
    
    }
    
    class ObjectB : ObjectBase
    {
    
    }
    
    class ObjectComparer : IEqualityComparer<ObjectBase>
    {
    	public bool Equals(ObjectBase a, ObjectBase b)
    	{
    		return a?.Item == b?.Item; 
    	}
    	public int GetHashCode(ObjectBase o)
    	{
    		return o.?Item?.GetHashCode() ?? 0;
    	}
    }
    // Very fast compared to your current approach. 1000x for my test case.
    var newList = objectAList.Except(objectBList, new ObjectComparer()).ToList();
