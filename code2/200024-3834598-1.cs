    class Repository: IRepository
    {
        IDataContext Context{get;set;}
    
        T Get<T>(int id) where T : EntityBase    
    	{
    		string[] interfaceList = new string[] 
    			{ "ITeacher", "IStudent"};
    
    		Type interfaceType = null;
    		foreach (string s in interfaceList)
    		{
    			var types = typeof(T).FindInterfaces((x, y) => x.Name == y.ToString(), s);
    
    			if (types.Length > 0)
    				interfaceType = types[0];
    		}
    
    		if (interfaceType == null)
    			throw new Exception("Unknown Interface " + typeof(T).Name);
    
    		MethodInfo method = typeof(Context).GetMethod("Get");
    		MethodInfo generic = method.MakeGenericMethod(interfaceType);
    		generic.Invoke(this, new object [] { id } );
    	}
