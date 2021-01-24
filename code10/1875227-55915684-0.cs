     public class DDSModel : INotifyPropertyChanged
     {
         public event PropertyChangedEventHandler PropertyChanged;
         protected void OnPropertyChanged([CallerMemberName] string property)
         {
              PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
         }
         private string _message;
         public string Message
         {
             get { return _message; }
             set { _message = value; OnPropertyChanged(); }
         }
     }
