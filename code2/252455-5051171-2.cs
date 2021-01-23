     public class CurrentSettings : INotifyPropertyChanged
     {
         private Color _Color;
         public Color Color
         {
            get { return _Color; }
            set { _Color = value; NotifyPropertyChanged("Color"); }
         }
         private void NotifyPropertyChanged(string name)
         {
             if (PropertyChanged != null)
                 PropertyChanged(this, new PropertyChangedEventArgs(name);
         }
         public event PropertyChangedEventHandler PropertyChanged;
     }
