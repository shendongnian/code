	public string FunnyName(string firstName)
    {
		var s = new System.Text.StringBuilder();
		
        for (int i = 0; i < firstName.Length; i++)
            for (int j = 0; j <= i; j++)
				s.Append(firstName[j]);
		
        return s.ToString();
    }
