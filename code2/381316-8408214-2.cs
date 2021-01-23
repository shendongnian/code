    public class EditBase
    {
    	public int ID { get; set; }
    	public string Username { get; set; }
    	public DateTime CreatedDate { get; set; }
    }
    
    public class Repository
    {
    	private Dictionary<RepositoryKey, EditBase> _store = new Dictionary<RepositoryKey, EditBase>();
    
    	public void Add(EditBase model)
    	{
    		_store.Add(new RepositoryKey(model), model);
    	}
    
    	public void Remove(EditBase model)
    	{
    		_store.Remove(new RepositoryKey(model));
    	}
    
    	public void Remove<T>(int id)
    		where T : EditBase
    	{
    		_store.Remove(new RepositoryKey(typeof(T), id));
    	}
    
    	public bool TryGet<T>(int id, out T value)
    		where T : EditBase
    	{
    		EditBase editBase;
    		if (!_store.TryGetValue(new RepositoryKey(typeof(T), id), out editBase)) {
    			value = null;
    			return false;
    		}
    		value = (T)editBase;
    		return true;
    	}
    
    	private class RepositoryKey : IEquatable<RepositoryKey>
    	{
    		private Type _modelType;
    		private int _id;
    
    		public RepositoryKey(EditBase model)
    		{
    			_modelType = model.GetType();
    			_id = model.ID;
    		}
    
    		public RepositoryKey(Type modelType, int id)
    		{
    			_modelType = modelType;
    			_id = id;
    		}
    
    		#region IEquatable<IdentityKey> Members
    
    		public bool Equals(RepositoryKey other)
    		{
    			if (_modelType != other._modelType) {
    				return false;
    			}
    			return _id == other._id;
    		}
    
    		#endregion
    
    		public override int GetHashCode()
    		{
    			return _modelType.GetHashCode() ^ _id.GetHashCode();
    		}
    	}
    }
