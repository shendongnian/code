    public class Student :INotifyPropertyChanged
    {
       public string Firstname { set; get; }
       public event PropertyChangedEventHandler PropertyChanged;
       private void NotifyPropertyChanged(String info)
       {
          UpdateModifiedTimestamp(); // update the timestamp
          if (PropertyChanged != null)
          {
              PropertyChanged(this, new PropertyChangedEventArgs(info));
          }
       }
       string _firstname;
       public string Firstname  //same for other properties
       {
         get
         {
             return _firstname;
         }
         set
         {
            if (value != _firstname)
            {
                _firstname = value;
                NotifyPropertyChanged("Firstname");
            }
         }
       }
     }
