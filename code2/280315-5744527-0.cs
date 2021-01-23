    private bool isIt;
    public Action YourAction{get; set;}
    
    public bool IsIt
    {
    get{return isIt;}
    set{isIt = value; if(YourAction != null) YourAction();}
    }
