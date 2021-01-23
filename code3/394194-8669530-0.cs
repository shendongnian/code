    bool test = Page.IsPostBack;
    public bool MyPostBack
    {
        get{ return test; }
        set{ test = value; }
    }
