    void Main()
    {
    	List<UserProfile> u1 = new List<UserQuery.UserProfile>(){
    		new UserProfile(){ID = 1, FirstName  = "Super" , LastName = "Man"},
    		new UserProfile(){ID=2, FirstName = "Spider", LastName="Man"},
    		new UserProfile(){ID=3, FirstName = "Bat", LastName="Man"}
    	};
    	
    	List<UserProfile> u2 = new List<UserProfile>(){
    		new UserProfile(){ID = 1, FirstName="Super", LastName="Man"},
    		new UserProfile(){ID = 2, FirstName="Thor", LastName="Ragnarok"},
    		new UserProfile(){ID = 3, FirstName="Hulk", LastName="Baner"}
    	};
    	
    //	u1.Intersect(u2, new UserProfileComparer())
    //		.ToList()
    //		.ForEach(x => Console.WriteLine(x.Name));
    
    //	u1.Except(u2, new UserProfileComparer())
    //		.ToList()
    //		.ForEach(x => Console.WriteLine(x.Name));
    	
    	// (u1 + u2) - (u1*u2)
    	u1.Union(u2, new UserProfileComparer())
    		.Except(u1.Intersect(u2, new UserProfileComparer()))
    		.Distinct()
    		.ToList()
    		.ForEach(x => Console.WriteLine(x.Name));
    }
    
    class UserProfile
    {
    	public int ID {get;set;}
    	public string Name => LastName + "," + FirstName;
    	public string FirstName {get;set;}
    	public string LastName {get;set;}
    }
    
    class UserProfileComparer : IEqualityComparer<UserProfile>
    {
    	public bool Equals(UserProfile item1, UserProfile item2)
    	{
    		if (object.ReferenceEquals(item1, item2))
    			return true;
    		if (item1 == null || item2 == null)
    			return false;
    		return item1.FirstName.Equals(item2.FirstName) &&
    			   item1.LastName.Equals(item2.LastName);
    	}
    
    	public int GetHashCode(UserProfile item)
    	{
    		return new { item.FirstName, item.LastName }.GetHashCode();
    	}
    }
