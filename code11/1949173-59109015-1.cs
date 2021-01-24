    public Entity GetById(int id)
    {
    	string _name = string.Empty;
    
    	if (!_cache.TryGetValue(id, out _name))
    	{
    		var _entity = db.GetById(id);
    
    		_cache.Set(_entity.Id, _entity.Name);
    	}
    
    	return _cache.Get<Entity>(id);
    }
