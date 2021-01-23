    public void Login(Stream stream)
    {
	    string username = null;
	    string password = null;
	
	    HttpContentParser parser = new HttpContentParser(stream);
        if (parser.Success)
        {
	        username = HttpUtility.UrlDecode(parser.Parameters["username"]);
	        password = HttpUtility.UrlDecode(parser.Parameters["password"]);
        }
    }
