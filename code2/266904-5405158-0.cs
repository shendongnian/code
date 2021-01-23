    private ColumnsModel _columns;
    public ColumnsModel Columns 
    { 
      get { return _columns; } 
      set 
      { 
        _columns = value; 
        PropertyChanged("Columns"); 
      }
    }
