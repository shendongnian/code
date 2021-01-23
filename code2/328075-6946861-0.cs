    public Cow Model
    {
        get
        {
            return this.DataContext as Cow;
        }
        set
        {
            this.DataContext = value;
        }
    }
  
