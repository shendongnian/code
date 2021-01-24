    public string SelectedSecond 
                  {
                         get { return _selectedSecond ; }
                         set
                         {
                               _selectedSecond  = value;
                               PropertyChanged(this, new PropertyChangedEventArgs("Second"));
                         }
                  }
