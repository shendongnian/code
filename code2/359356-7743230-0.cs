    private bool _isChecked = false;
    public bool IsChecked
    {
      get { return _isChecked; }
      set 
      {
        if( value != _isChecked ) {
          _isChecked = value;
          NotifyPropertyChanged( "IsChecked" );
        }
      }
    }
