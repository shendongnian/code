    if (userId == 0){
    	CookieHelper myCookie = new Cookie(_app);
    	if (myCookie  != null)
    	{
    		userId = Convert.ToInt32(System.Web.HttpContext.Current.Request.Cookies[myCookie.CookieName]["userId"]);
    		if(userId>0)
    		{
    		   SessionHelper.SetSession(userId);
    		}
    	}
    }
