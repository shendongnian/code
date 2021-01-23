	public class SerialiserCache
	{
		private static readonly SerialiserCache _current = new SerialiserCache();
		private Dictionary<Type, XmlSerializer> _cache = new Dictionary<Type, XmlSerializer>();
		private SerialiserCache()
		{
			
		}
		public static SerialiserCache Current
		{
			get { return _current; }
		}
		public XmlSerializer this[Type t]
		{
			get
			{
				LoadIfNecessary(t);
				return _cache[t];
			}
		}
		private void LoadIfNecessary(Type t)
		{
			// double if to prevent race conditions 
			if (!_cache.ContainsKey(t))
			{
				lock (_cache)
				{
					if (!_cache.ContainsKey(t))
					{
						_cache[t] = new XmlSerializer(typeof(T));
					}
				}
			}
		}
	}
