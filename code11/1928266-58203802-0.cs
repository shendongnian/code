		string test = "ThisIsMyAMAZONDescription";
		var tuples = test.Select((a,b) => Tuple.Create(a, b));
		var list = tuples.Select((x, i) => 
                             i > 0 
                             && char.IsUpper(x.Item1) 
                             && (!char.IsUpper(tuples.ElementAt(i - 1).Item1) 
                              || !char.IsUpper(tuples.ElementAt(i + 1).Item1)) ? 
                                 "_" + x.Item1.ToString() : x.Item1.ToString());
		var result = string.Concat(list);
		
		Console.WriteLine(result);
        //This_Is_My_AMAZON_Description
