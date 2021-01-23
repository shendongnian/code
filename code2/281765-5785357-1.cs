    protected bool NoJavascript
    {
        get 
        {
            TempCookie cookie = new TempCookie(); // session only cookie
            if (cookie.NoJavascript) return true;
            bool noJavascript = !string.IsNullOrEmpty(Request["noscript"]);
            if (noJavascript)
                cookie.NoJavascript = noJavascript;
            return noJavascript;
        }
    }
    
    protected string NoScriptPlaceHolder
    {
        get
        {
            if (NoJavascript)
                return string.Empty;
            string url = Request.Url.ToString();
            string adv = "?";
            if (url.Contains('?'))
                adv = "&";
            string meta = string.Format("<META HTTP-EQUIV=\"Refresh\" CONTENT=\"0; URL={0}{1}noscript=true\">",
                url, adv);
            return meta;
        }
    }
