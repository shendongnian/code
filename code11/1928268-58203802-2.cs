	sring test = "ThisIsMyAMAZONDescriptionX";
    var list = test.Select((x, i) => 
                           (i > 0 
                            && i < test.Length - 1 
                            && char.IsUpper(x) 
                            && (!char.IsUpper(test.ElementAt(i - 1)) 
                             || !char.IsUpper(test.ElementAt(i + 1))) 
                           || (i == test.Length -1  && char.IsUpper(x))) ? 
                             "_" + x.ToString() : x.ToString());		
    var result = string.Concat(list);
		
	Console.WriteLine(result);
    //This_Is_My_AMAZON_Description_X
