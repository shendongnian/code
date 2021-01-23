    public bool CanSave
    {
      get{ return canSave; }
      set{ canSave = value; RaisePropertyChanged( "CanSave" ); }
    }
    private bool canSave;
    public string this[string columnName]
    {
      //....
      CanSave = Result == String.Empty;
    }
    //xaml
    <Button IsEnabled={Binding Path=CanSave}>Save</Button>
