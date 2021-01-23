    public class Items : IEnumerator<KeyValuePair<string, Configuration>>  
    {        
        private Dictionary<string, Configuration> _items = new Dictionary<string, Configuration>();        
        public Configuration this[string element]       
        {            
            get
            {
                if (_items.ContainsKey(element))
                {
                    return _items[element];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                 _items[element] = value;
            }
        }
		int current;
		public object Current
		{
			get { return _items.ElementAt(current); }
		}
		public bool MoveNext()
		{
			if (_items.Count == 0 || _items.Count <= current)
			{
				return false;
			}
			return true;
		}
		public void Reset()
		{
			current = 0;
		}
		public IEnumerator GetEnumerator()
		{
			return _items.GetEnumerator();
		}
		KeyValuePair<string, Configuration> IEnumerator<KeyValuePair<string, Configuration>>.Current
		{
			get { return _items.ElementAt(current); }
		}
		public void Dispose()
		{
		    //Dispose here
		}
    }
