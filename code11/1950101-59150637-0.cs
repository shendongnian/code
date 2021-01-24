    public ActionResult EditCustomer(int id)
    {
        string requestData = "";
    	using (Stream iStream = Request.InputStream)
    	{
    		using (StreamReader reader = new StreamReader(iStream, Encoding.UTF8))   //you should use   Request.ContentEncoding
    		{
    			requestData = reader.ReadToEnd();
    		}
    	}
        NameValueCollection data = HttpUtility.ParseQueryString(requestData);
        string Search = Convert.ToString(Request["search[value]"]);     
    }
