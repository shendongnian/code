    public class Bar : INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged;
      private string foo;
      public string Foo 
      {
        get { return this.foo; }
        set 
        { 
          if(value==this.foo) 
            return;
          this.foo = value;
          this.OnPropertyChanged("Foo");
        }
      }
      private void OnPropertyChanged(string propertyName)
      {
        if(this.PropertyChanged!=null)
          this.PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
      }  
    }
