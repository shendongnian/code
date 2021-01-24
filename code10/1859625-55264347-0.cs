    public class formData : INotifyPropertyChanged
    {
        private string primaryUserNameValue;
        public string PrimaryUserName
        {
            get
            {
                return primaryUserNameValue;
            }
            set
            {
                if (primaryUserNameValue != value)
                {
                    primaryUserNameValue = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
