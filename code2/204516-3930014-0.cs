    List<ObjectType> listQueries = new List<ObjectType>();
    
    ObjectTypeEqualityComparer objectTypeComparer = new ObjectTypeEqualityComparer();
    
    listQueries.AddRange(subQuery1);// your first query
    listQueries.AddRange(subQuery2); // your second query
    ObjectType[] result = listQueries.Distinct(objectTypeComparer).ToArray();
    class ObjectTypeEqualityComparer : IEqualityComparer<ObjectType>
    {
    	public bool Equals(ObjectType obj1, ObjectType obj2)
    	{
    		return obj1.UserId == obj2.UserId ?  true : false;
    	}
    
    	public int GetHashCode(ObjectType obj)
    	{
    		return obj.UserId.GetHashCode();
    	}
    
    }
