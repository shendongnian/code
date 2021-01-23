    public class Test : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
       private string name;
       public string Name
       {
          get { return this.name; }
          set { this.name = value; OnNotifyPropertyChanged("Name"); }
       }
       protected virtual void OnPropertyChanged(string name)
       {
           EventHamanger.OnEvent(this, PropertyChanged, new PropertyChangedEventArgs(name));
       }
    }
