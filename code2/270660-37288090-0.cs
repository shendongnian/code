    private readonly ConcurrentDictionary<Type, List<object>> ObjectList = new ConcurrentDictionary<Type, List<object>>();
	public int Add<T>(T obj) where T : IIdentifier
	{
		// instantiate if list does not exist for this object type
		if (!ObjectList.ContainsKey(typeof (T)))
			ObjectList[typeof(T)] = new List<object>();
		// get id
		var id = GetId<T>() + 1;
		// add object to list
		obj.Id = id;
		ObjectList[typeof(T)].Add(obj);
		return id;
	}
	public void Attach<T>(T obj) {
		// do not need to do anything
	}
	
	public T Get<T>(int id) where T : class, IIdentifier
	{
		// check list exist
		if (!ObjectList.ContainsKey(typeof (T)))
			return null;
		return ObjectList[typeof(T)].OfType<T>().FirstOrDefault(n => n.Id == id);
	}
	public List<T> GetAll<T>(Func<T, bool> predicate) where T : new()
	{
		// check list exist
		if (!ObjectList.ContainsKey(typeof(T)))
			return null;
		return ObjectList[typeof(T)].OfType<T>().Where(predicate).ToList();
	}
	public List<T> GetAll<T>()
    {
        return ObjectList[typeof(T)].OfType<T>.ToList();
    }
	public IQueryable<T> Query<T>()
    {
        return GetAll<T>.AsQueryable();
    }
	
	public int Remove<T>(int id) where T : IIdentifier
	{
		// check list exist
		if (!ObjectList.ContainsKey(typeof(T)))
			return 0;
		// find object with matching id
		for (var i = 0; i < ObjectList[typeof(T)].Count; i++)
			if (ObjectList[typeof(T)].OfType<T>().ToList()[i].Id == id)
			{
				ObjectList[typeof(T)].RemoveAt(i);
				return id;
			}
		// object not found
		return 0;
	}
	public int Save<T>(T obj) where T : IIdentifier
	{
		// check list exist
		if (!ObjectList.ContainsKey(typeof(T)))
			return 0;
		// find object with matching id
		for (var i = 0; i < ObjectList[typeof(T)].Count; i++)
			if (ObjectList[typeof(T)].OfType<T>().ToList()[i].Id == obj.Id)
			{
				ObjectList[typeof (T)][i] = obj;
				return obj.Id;
			}
		// object not found
		return 0;
	}
	#region Helper methods
	private int GetId<T>() where T : IIdentifier
	{
		return ObjectList[typeof(T)].Count == 0 ? 0 : ObjectList[typeof(T)].OfType<T>().Last().Id;
	}
	#endregion
