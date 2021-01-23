	public class Cat : IEnumerable<KeyValuePair<string,string>>
	{
		private Dictionary<string,string> catNameAndType = new Dictionary<string,string>();
	
		public Cat()
		{
	
		}
	
		public void Add(string catName, string catType)
		{
			catNameAndType.Add(catName,catType);
		}
	
		public IEnumerator<KeyValuePair<string,string>> GetEnumerator() 
		{
			return catNameAndType.GetEnumerator();
		}
		
		IEnumerator IEnumerable.GetEnumerator() 
		{
			return GetEnumerator();
		}
	}
	
