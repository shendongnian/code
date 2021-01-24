    //Sample data to work with
    var products = new List<KeyValuePair<string, int>>();
    products.Add(new KeyValuePair<string, int>("A", 12));
    products.Add(new KeyValuePair<string, int>("B", 23));
    products.Add(new KeyValuePair<string, int>("C", 62));
    products.Add(new KeyValuePair<string, int>("D", 17));
    products.Add(new KeyValuePair<string, int>("E", 11));
    products.Add(new KeyValuePair<string, int>("F", 75));
    products.Add(new KeyValuePair<string, int>("G", 95));
    products.Add(new KeyValuePair<string, int>("H", 24));
    products.Add(new KeyValuePair<string, int>("I", 85));
    products.Add(new KeyValuePair<string, int>("J", 41));
    products.Add(new KeyValuePair<string, int>("K", 76));
    products.Add(new KeyValuePair<string, int>("L", 77));
    products.Add(new KeyValuePair<string, int>("M", 33));
    products.Add(new KeyValuePair<string, int>("N", 81));
    products.Add(new KeyValuePair<string, int>("O", 34));
    products.Add(new KeyValuePair<string, int>("P", 45));
    //Sort the collection
    List<KeyValuePair<string, int>> ordered = products.OrderBy(x => x.Value).ToList();
    //Put linear results into 2D array (4x4)
    var matrix = new KeyValuePair<string, int>[4,4];
    for (int i = 0; i < 4; i++)
        for (int j = 0; j < 4; j++)
    	    matrix[i, j] = ordered[i * 4 + j];
    
    //Write out results
    for (int i = 0; i < 4; i++) {
    	for (int j = 0; j < 4; j++) {
    		var c = ordered[i * 4 + j];
    		Console.Write(c.Key + ": " + c.Value.ToString() + "    ");
    	}
   		Console.WriteLine();
   	}
