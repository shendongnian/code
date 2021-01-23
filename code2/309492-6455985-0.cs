    	Hashtable openWith = new Hashtable();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		// Add some elements to the hash table. There are no 
		// duplicate keys, but some of the values are duplicates.
		openWith.Add("txt", "notepad.exe");
		openWith.Add("bmp", "paint.exe");
		openWith.Add("dib", "paint.exe");
		openWith.Add("rtf", "wordpad.exe");
		foreach (string key in openWith.Keys)
		{
			dictionary.Add(key, openWith[key].ToString());
		}
