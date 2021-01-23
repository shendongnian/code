    	[Serializable]
    	public class AjaxDictionary<TKey, TValue> : ISerializable
    	{
    		private Dictionary<TKey, TValue> _Dictionary;
    		public AjaxDictionary()
    		{
    			_Dictionary = new Dictionary<TKey, TValue>();
    		}
    		public AjaxDictionary( SerializationInfo info, StreamingContext context )
    		{
    			_Dictionary = new Dictionary<TKey, TValue>();
    		}
    		public TValue this[TKey key]
    		{
    			get { return _Dictionary[key]; }
    			set { _Dictionary[key] = value; }
    		}
    		public void Add(TKey key, TValue value)
    		{
    			_Dictionary.Add(key, value);
    		}
    		public void GetObjectData( SerializationInfo info, StreamingContext context )
    		{
    			foreach( TKey key in _Dictionary.Keys )
    				info.AddValue( key.ToString(), _Dictionary[key] );
    		}
    	}
