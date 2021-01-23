    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
    public static SomeObj AHandyWebService()
    {
    
    	SomeObj mySomeObj;
    
    	try
    	{
    		mySomeObj = getSomeObj();
    		HttpCookie appCookie = new HttpCookie("FOOAPP");
    		appCookie.Value = String.Format("Written: {0:yyyy-MM-dd}", System.DateTime.Now.ToUniversalTime());
    		appCookie.Expires = System.DateTime.Now.ToUniversalTime().AddMinutes(1);
    		appCookie.Path = HttpContext.Current.Request.ApplicationPath;
    		HttpContext.Current.Response.Cookies.Add(appCookie);
    	}
    	catch (Exception ex)
    	{
    		throw;
    	}
    	return mySomeObj;
    }
