    private int _age;
    //#1
    public event System.EventHandler AgeChanged;
    //#2
    protected virtual void OnAgeChanged()
    { 
         if (AgeChanged != null) AgeChanged(this,EventArgs.Empty); 
    }
    
    public int Age
    {
        get
        {
             return _age;
        }
        
        set
        {
             //#3
             _age=value;
             OnAgeChanged();
        }
     }
