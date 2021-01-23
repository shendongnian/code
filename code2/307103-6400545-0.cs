    public bool SearchClicked
    {
    get { return  ViewState["bool"] == null ? false : (bool)ViewState["bool"]; }
    set { ViewState["bool"] = value; }
    }
