    public ObservableCollection<InsertionVM> Insertions
        {
            get
            {
                return _insertions;
            }
            set
            {
    	   if(_insertions != value)
               {
                   _insertions = value;
                   base.OnPropertyChanged("Insertions");
               }
            }
        }
