    public class Person : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
       private void OnPropertyChanged(string propertyName)
       {
          PropertyChangedEventHandler h = PropertyChanged;
          if (h != null)
          {
             h(this, new PropertyChangedEventArgs(propertyName));
          }
       }
       public Person() { }
       public Person(string name)
       {
          Name = name;
       }
       private string _Name = "I was created by the parameterless constructor";
       public string Name
       { 
          get { return _Name; }
          set
          {
             if (_Name == value)
             {
                return;
             }
             _Name = value;
             OnPropertyChanged("Name");
          }
       }
    }
