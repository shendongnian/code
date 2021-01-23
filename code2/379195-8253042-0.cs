    public String GetEMailAddresses(string Input)
    {
      	System.Text.RegularExpressions.MatchCollection MC = System.Text.RegularExpressions.Regex.Matches(Input, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
    
    	for (int i = 0; i <= MC.Count - 1; i++) {
    		if (Results.Contains(MC[i].Value) == false) {
    			return MC[i].Value;
    		}
    	}
    
    	return "";
    }
