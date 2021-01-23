    //Start with setting up the dictionary you described.
    Dictionary<string, int> dict = new Dictionary<string, int>{
    	{"key1", 2},
    	{"key2", 2},
    	{"key3", 3},
    	{"key4", 2},
    	{"key5", 5},
    	{"key6", 5}
    };
    IEnumerable<IGrouping<int, int>> grp = dict.Values.GroupBy(x => x);
    //Two options now. One is to use the results directly such as with the
    //equivalent code to output this and prove it worked:
    foreach(IGrouping<int, int> item in grp)//note - not sorted, that must be added if needed
    	Console.WriteLine("{0} - {1}", item.Key, item.Count());
    //Alternatively, we can put these results into another collection for later use:
    Dictionary<int, int> valCount = grp.ToDictionary(g => g.Key, g => g.Count());
    //Finally some code to output this and prove it worked:
    foreach(KeyValuePair<int, int> kvp in valCount)//note - not sorted, that must be added if needed
    	Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
