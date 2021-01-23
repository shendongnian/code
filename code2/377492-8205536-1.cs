    for (int i = 0; i < listBox1.Items.Count; ++i)
    {
      string input = listbox1.Items[i].Text;
    
    	// Here we call Regex.Match.
    	Match match = Regex.Match(input, @"hi", RegexOptions.IgnoreCase);
    
    	// Here we check the Match instance.
    	if (match.Success)
    	{
        
             listBox1.Items.RemoveAt(i--);
    
    	}
    
    }
