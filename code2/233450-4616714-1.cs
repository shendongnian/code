       MyControl control = new MyControl();
       control.PropertyChanged += OnPropertyChanged;
        
       void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
       {
          if (e.PropertyName == "CurrentColor")
          {
              //do stuff...
          }
       }
