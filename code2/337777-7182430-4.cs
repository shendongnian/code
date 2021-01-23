    using System.ComponentModel;
    public partial class WPFGrid : Window, INotifyPropertyChanged
    {
    
       public event PropertyChangedEventHandler PropertyChanged;
    
          private void OnPropertyChanged(string propertyName)
          {
             if (PropertyChanged != null)
             {
                PropertyChanged(this, new PropertyChangedEventArgs(e));
             }
          }
    }
