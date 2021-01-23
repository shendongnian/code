    class VariableVieWModel : INotifyPropertyChanged
        { .
          .
                public ObservableCollection<VariableModel> Variables
                {
                   get
                   {
                      return vars;
                   }
                   set
                   {
                      if(vars!=value)
                      {
                          vars = value;
                          OnPropertyChanged("Variables");
                      }
                   }
                }
    
                public event PropertyChangedEventHandler PropertyChanged;      
                protected void OnPropertyChanged(string name)
                {
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null)
                    {
                        handler(this, new PropertyChangedEventArgs(name));
                    }
                } 
        }
