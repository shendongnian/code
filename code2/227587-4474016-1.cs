    public int CustomerId
    {
       get { return (int)(ViewState["CustomerId"] ?? -1); }
       set { ViewState["CustomerId"] = value; }
    }
