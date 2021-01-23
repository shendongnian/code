    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["culture"] != null)
                    ddlLanguage.SelectedValue = Session["culture"].ToString();
                else
                {
                    ddlLanguage.SelectedValue = "en-US";
                    Session["culture"] = "en-US";
                }
            }
        }
    
        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["culture"] = ddlLanguage.SelectedValue;
            Response.Redirect(GetThisPageNameWithQueryString());
        }
    
        public String GetThisPageNameWithQueryString()
        {
            String pageName = GetThisPageName(false);
    
            String queryParam = ServerVariables("QUERY_STRING");
    
            if (!String.IsNullOrEmpty(queryParam))
            {
                if (queryParam.Contains("qs=true"))
                    pageName = pageName + "?" + queryParam;
            }
    
            return pageName;
        }
    
        public String GetThisPageName(bool includePath)
        {
            String s = ServerVariables("SCRIPT_NAME");
            if (!includePath)
            {
                int ix = s.LastIndexOf("/");
                if (ix != -1)
                {
                    s = s.Substring(ix + 1);
                }
            }
            return s;
        }
    
        public String ServerVariables(String paramName)
        {
            String tmpS = String.Empty;
            if (HttpContext.Current.Request.ServerVariables[paramName] != null)
            {
                try
                {
                    tmpS = HttpContext.Current.Request.ServerVariables[paramName].ToString();
                }
                catch
                {
                    tmpS = String.Empty;
                }
            }
            return tmpS;
        }
