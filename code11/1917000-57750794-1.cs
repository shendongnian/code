    private string _passWord;
    
     public event PropertyChangedEventHandler PropertyChanged;
     private void OnPropertyChanged([CallerMemberName] string propertyName = null)
     {
         if (PropertyChanged != null)
         {
             this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
         }
     }
     public string PassWord
     {
    
         get { return _passWord; }
         set
         {
             _passWord = value;
             OnPropertyChanged();
                
         }
     }
