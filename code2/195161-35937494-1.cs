	void Main()
	{
		var list1 = new List<string>() { "a", "b", "d" }; // a list
		var myDict = new Dictionary<string, object>(); // the dictionary
		myDict.Add("a", "123"); myDict.Add("b", "456"); myDict.Add("c", "789"); 
	
		var myDict2 = new Dictionary<string, object>(); // 2nd dictionary
		myDict2.Add("a", "123"); myDict2.Add("b", "456"); myDict2.Add("c", "789"); 
		
		myDict.Add("d", myDict2); // add 2nd to first dictionary
	
		// simple query on dictionary
		var q1 = myDict.QueryDictionary(w => list1.Any(a => a == w.Key));
		q1.Dump();
	
		// query dictionary of dictionary (q3 contains result)
		var q2 = 
		  (Dictionary<string, object>)q1.QueryDictionary(w => w.Key.Equals("d")).First().Value;	
		var q3 = q2.QueryDictionary(w => w.Key.Equals("b"));
		q3.Dump();
	}
	
	// Extension
	public static class Extensions
	{
		public static Dictionary<string, T> QueryDictionary<T>(
		   this Dictionary<string, T> myDict, 
		   Expression<Func<KeyValuePair<string, T>, bool>> fnLambda)
		{
			return myDict.AsQueryable().Where(fnLambda).ToDictionary(t => t.Key, t => t.Value);
		}
	}
	
