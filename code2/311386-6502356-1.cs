    public bool IsACheckedProperty
    {
        get
        {
           return associated var;
        }
        set
        { 
           var = val; 
           if(var)
               IsBEnabled = false;
           else
               IsBEnabled = true;
        }
    }
