    public string SessionStore
    {
        get 
        { 
            if( Session["MyData"] == null )
            {
                return "default value";
            }
            
            return (string)(Session["MyData"]);
        }
        set { Session["MyData"] = value; }
    }
