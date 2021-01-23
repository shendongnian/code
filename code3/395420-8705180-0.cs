	List<string> collection = new List<String> { "Hello", "World", "One", "Two", "Three"};
	collection.Dump("Original List");
	for(int i = collection.Count-1; i>=0; i-- )
	{
		if (collection[i] == "One"){
			collection.RemoveAt(i);
		}
	}
	collection.Dump("After deleting");
