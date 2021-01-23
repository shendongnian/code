    public class MySuperDictionary
	{
	    private readonly Dictionary<KEY, VALUE>[] dictionaries;
		
		public MySuperDictionary()
		{
		    this.dictionaries = new Dictionary<KEY, VALUE>[373]; // must be a prime number.
		    for (int i = 0; i < dictionaries.Length; ++i)
		        dictionaries[i] = new Dicionary<KEY, VALUE>(13000000 / dictionaries.Length);
		}
		
		public void Add(KEY key, VALUE value)
		{
		    int bucket = (GetSecondaryHashCode(key) & 0x7FFFFFFF) % dictionaries.Length;
			dictionaries[bucket].Add(key, value);
		}
		
		public bool Remove(KEY key)
		{
		    int bucket = (GetSecondaryHashCode(key) & 0x7FFFFFFF) % dictionaries.Length;
			return dictionaries[bucket].Remove(key);
		}
		
		public bool TryGetValue(KEY key, out VALUE result)
		{
		    int bucket = (GetSecondaryHashCode(key) & 0x7FFFFFFF) % dictionaries.Length;
			return dictionaries[bucket].TryGetValue(key, out result);
		}
		public static int GetSecondaryHashCode(KEY key)
		{
		    here you should return an hash code for key possibly using a different hashing algorithm than the algorithm you use in inner dictionaries
		}
	}
