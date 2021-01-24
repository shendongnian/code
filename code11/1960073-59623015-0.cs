     public  class SubItems: INotifyPropertyChanged
        {    
            public void changeTheme(bool islight) {
              if ("Menu".Equals(Title)) { // if the function is only for only `Menu` Item
                 if (islight)
                 {// set to light theme
                    if ( !App.isLightThemeApplied)
                    {  
                        IconSource = "menu.png";
                    }
                 }
                 else
                 {//set to unlight theme
                    if (App.isLightThemeApplied) {
                        IconSource = "down.png";
                    }
                 }
              }
            }    
    
            string _title;
            public string Title
            {
                set { SetProperty(ref _title, value); }
    
                get { return _title; }
            }
    
            string _iconSource;
            public string IconSource
            {
                set { SetProperty(ref _iconSource, value); }
    
                get { return _iconSource; }
            }    
    
            bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
            {
                if (Object.Equals(storage, value))
                    return false;
    
                storage = value;
                OnPropertyChanged(propertyName);
                return true;
            }
    
            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
