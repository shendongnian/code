        public class UserData : INotifyPropertyChanged
        {
           private bool m_value;
           public bool Value
           {
              get { return m_value; }
              set
              {
                 if (m_value == value)
                    return;
                 m_value = value;
                 if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));
              }
           }
           public event PropertyChangedEventHandler PropertyChanged;
       }
