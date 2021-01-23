    [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
    public string MyTextProperty{
        get
        {
           return ViewState["Text"] != null ? (string)ViewState["Text"] : string.Empty;
        }
        set
        {
            this.ViewState["Text"] = value;
        }
    }
