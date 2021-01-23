    public int ClickCount
    {
        get
        {
            return (int)(ViewState["ClickCount"] ?? 0);
        }
        set
        {
            ViewState["ClickCount"] = value;
        }
    }
