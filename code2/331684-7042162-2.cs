    //child
    public string DatatoShare{get;set;}
    protected override Onload()
    {
    DatatoShare = "Whatever you want"
    base.Onload()
    }
    //parent
    private ChildUserControl child;
    public string NeedChildsData()
    {
    return child.DatatoShare
    }
