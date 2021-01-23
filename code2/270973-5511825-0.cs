    public MyData SessionStore
    {
        get { return (MyData)(Session["MyData"]) ?? new MyData(); }
        set { Session["MyData"] = value; }
    }
