    protected string UserName {
        get { 
            string retVal=string.Empty;
            if (!string.IsNullOrEmpty(Session["UserName"]))
                retVal=Session["Username"].ToString();
            return retVal;
        }
        set{
            Session["UserName"]=value;
        }
    }
