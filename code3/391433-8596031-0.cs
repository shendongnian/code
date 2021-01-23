    var u = Request.Url;
    if(u.Query.Contains("%20"))
    {
    	var ub = new UriBuilder(u);
    	Console.WriteLine(ub.Query);
    	string query = ub.Query;
    	//note bug in Query property - it includes ? in get and expects it not to be there on set
    	ub.Query = ub.Query.Replace("%20", "+").Substring(1);
    	Response.StatusCode = 301;
    	Response.RedirectLocation = ub.Uri.AbsoluteUri;
    	Response.End();
    }
