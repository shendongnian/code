    private string _Text;    
    public string Text
    {
       get { return _Text ?? "Your Default"; }
       set { _Text = value; }
    }
