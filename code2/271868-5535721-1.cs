    public string SessionStore
    {
        get { return (string)(Session["MyData"]) ?? "default value"; }
        set { Session["MyData"] = value; }
    }
