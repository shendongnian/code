    public static IList<MyData> Data {
        get
        {
            if (Application["MyIListData"] != null)
                return (IList<MyData>)Application["MyIListData"];
            else
                return new IList<MyData>();
        }
        set
        {
            Application["MyIListData"] = value;    
        }
    } 
    protected void Application_Start(object sender, EventArgs e)
    {
        Data = Load();
    }
