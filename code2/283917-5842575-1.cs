    private int _age;
    public event System.EventHandler AgeChanged;
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
             _age=value;
             OnAgeChanged();
        }
     }
