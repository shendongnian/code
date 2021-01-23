    public String GetEMailAddresses(string Input)
    {
      	System.Text.RegularExpressions.MatchCollection MC = System.Text.RegularExpressions.Regex.Matches(Input, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
    
    	if(MC.Count > 0)
            return MC[0].Value;
    		 
    	return "";
    }
