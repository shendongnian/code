    public List<string> findAllOccurance(string str)
    {
        List<string> result = new List<string>();
	    for (int i = 1; i < str.Length; i++)
	    {
	      for (int j=0; j <= str.Length-i; j++)
	        result.Add(str.Substring(j,i));
	    }
        return result.Distinct().ToList();
    }
