	public static void Main()
	{
       var db = new List<Dictionary<string, int>>()
            {
                new Dictionary<string, int>(){ {"a", 1 }, { "b", 5 }, { "c", 3 } },
                new Dictionary<string, int>(){ {"d", 5 }, { "b", 3 } },
                new Dictionary<string, int>(){ {"a", 2 }, { "c", 2 } },
            };
        Console.Write(GetMin(db, "a").ToString());
  
	}
	
    public static int GetMin(List<Dictionary<string, int>> db, string key)
    {
		    return db == null || !db.Any(x=> x.ContainsKey(key)) ? 0 :
            db.SelectMany(x=> x).Where(x=> x.Key == key).Select(x=> x.Value).Min();
    }
    // Result you will get is 1
