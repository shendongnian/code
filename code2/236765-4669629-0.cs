    public bool CanSave
    {
      get
      {
        return this.IsDirty;     
      }
    }
    
    public bool IsDirty
    {
      get
      {
        if (this.ModelPropertyValue != this.ModelOriginalPropertyValue)
        {
          return true;  
        }
  
        return false;
      }
    }
    
    private string modelPropertyValue;
    public string ModelPropertyValue
    {
      get
      {
        return this.modelPropertyValue;
      }
  
      set
      {
        if (this.modelPropertyValue == value) 
        {
          return;
        }
  
        this.modelPropertyValue = value;
        OnPropertyChanged(() => this.ModelPropertyValue);
        OnPropertyChanged(() => this.CanSave);
      }
    }
