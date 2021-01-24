	public static void Main()
	{
        var dic = new Dictionary<string, List<int>>() {{"a", new List<int>() { 1, 2}}};
        Console.Write(GetMin(dic, "a").ToString());
  
	}
	
    public static int GetMin(Dictionary<string, List<int>> db, string key)
    {
		    return db==null || !db.ContainsKey(key) ? 0 :  db[key].Min();
    }
    // Result you will get is 1
