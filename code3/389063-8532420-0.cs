    Hashtable OldTable = new Hashtable();
	Hashtable NewTable = new Hashtable();
			foreach (DictionaryEntry entry in OldTable)
			{
				if(NewTable.ContainsKey(entry.Key))
				{
					//Do something?
				}
			}
