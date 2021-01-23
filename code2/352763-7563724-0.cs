    public Brush RootBackground
    {
      get { return _rootBackground; }
      set 
      {
        if( value != _rootBackground ) {
          _rootBackground = value;
          NotifyPropertyChanged( "RootBackground" );
        }
       }
    }
    private Brush _rootBackground = new SolidColorBrush( Colors.Transparent );
