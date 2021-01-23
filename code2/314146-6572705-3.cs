        class File : INotifyPropertyChanged  //  implementation not added
        {
            private string _name;
            public string Name
            {
                get { return _name; }
                set
                {
                    if(_name != value)
                    {
                        _name = value;
                        OnPropertyChanged("Name");
                    }
                }
            }
        
            private boolean _isSelected;
            public boolean IsSelected
            {
                get { return _isSelected; }
                set
                {
                    if(_isSelected != value)
                    {
                        _isSelected = value;
                        OnPropertyChanged("IsSelected");
                    }
                }
            }
        }
    
        class ViewDiskModel : INotifyPropertyChanged // implementation missing
        {
            private ObservableCollection<File> _files;
            
            public ObservableCollection<File> Files
            {
                get
                {
                    return _files;
                }
    set
                {
                    if(_files != value)
                    {
                        _files = value;
                        OnPropertyChanged("Files");
                    }
                }
            }
        } 
