    input = input.Replace("\t", " ");
    List<string> empties = new List<string>();
    for (int i=input.Length - 1; i>1; i--)
    {
    	string spcs = "";
    	for (int j=0; j<=i; j++)
    		spcs += " ";
    	if (input.Contains(spcs))
    		empties.Add(spcs);
    }
    
    foreach (string s in empties)
    	input = input.Replace(s, " ");
