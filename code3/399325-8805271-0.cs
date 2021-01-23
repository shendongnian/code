    List<string> someCollection = new List<string>();
    
    someCollection.Add("Hello");
    someCollection.Add("World");
    someCollection.Add("Hello");
    someCollection.Add("World");
    
    // Enumerate the collection
    foreach (string item in someCollection)
    {
    	// If the item is "World", remove it from the collection
    	if ("World".Equals(item))
    	{
    		someCollection.Remove(item); // This will throw an InvalidOperationException.
    	}
    }
