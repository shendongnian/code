    List<string> empties = new List<string>();
    for (int i=input.Length; i>1; i--)
    {
    	string spcs = "";
    	for (int j=0; j<i; j++)
    		spcs += " ";
    	if (input.Contains(spcs))
    		empties.Add(spcs);
    }
    
    input = input.Replace("\t", " ");
    foreach (string s in empties)
    	input = input.Replace(s, " ");
