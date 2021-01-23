    String ToPublicUrl(String firstName, String lastName, int userId)
    {
    	return String.Format("http://www.yoursite.com/public/{0}-{1}-{2}.aspx",
    		Regex.Replace(firstName, "[^a-zA-Z]", ""),
    		Regex.Replace(lastName, "[^a-zA-Z]", ""),
    		userId);
    }
