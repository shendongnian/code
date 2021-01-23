	public void Add<K>(K entity) where K : class
	{            
		context.CreateObjectSet<K>().AddObject(entity);
	}
	public K SingleOrDefault<K>(Expression<Func<K, bool>> predicate) where K : class
	{
		K entity = context.CreateObjectSet<K>().SingleOrDefault<K>(predicate);
		
		return entity;
	}
