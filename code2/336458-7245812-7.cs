    if (FormsAuthentication.EnableCrossAppRedirects)
    {
        text = context.Request.QueryString[name];
        if (text != null && text.Length > 1)
        {
        	if (!cookielessTicket && FormsAuthentication.CookieMode == HttpCookieMode.AutoDetect)
        	{
        		cookielessTicket = CookielessHelperClass.UseCookieless(context, true, FormsAuthentication.CookieMode);
        	}
        	try
        	{
        		formsAuthenticationTicket = FormsAuthentication.Decrypt(text);
        	}
        	catch
        	{
        		flag2 = true;
        	}
        	if (formsAuthenticationTicket == null)
        	{
        		flag2 = true;
        	}
        }
        if (formsAuthenticationTicket == null || formsAuthenticationTicket.Expired)
        {
        	text = context.Request.Form[name];
        	if (text != null && text.Length > 1)
        	{
        		if (!cookielessTicket && FormsAuthentication.CookieMode == HttpCookieMode.AutoDetect)
        		{
        			cookielessTicket = CookielessHelperClass.UseCookieless(context, true, FormsAuthentication.CookieMode);
        		}
        		try
        		{
        			formsAuthenticationTicket = FormsAuthentication.Decrypt(text);
        		}
        		catch
        		{
        			flag2 = true;
        		}
        		if (formsAuthenticationTicket == null)
        		{
        			flag2 = true;
        		}
        	}
        }
    }
