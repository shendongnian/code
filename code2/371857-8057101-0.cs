    //stores it in memory
    public string name {get;set;} 
  
    //viewstate backed property, preserved on postback when viewstate is enabled
    public string name {
        get
        {
            return (string )ViewState["name "] ?? String.Empty; //default value
        }
        set
        {
            ViewState["name "] = value;
        }
    }
