    protected bool IsJavaScript
    {
        get
        {
            return string.IsNullOrEmpty(Request["noscript"]);
        }
    }
    
    protected string NoScriptPlaceHolder
    {
        get
        {
            if (!IsJavaScript)
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
