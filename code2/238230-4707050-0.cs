    public class LoginInfo : INotifyPropertyChanged
    {
        private int _userID;
        private string _UserName;
        public event PropertyChangedEventHandler PropertyChanged;
        public int UserId
        {
            get { return this._userID; }
            set
            {
                if (value != this._userID)
                {
                    this._userID = value;
                    NotifyPropertyChanged("UserID");
                }
            }
        }
        public string Username
        {
            get { return this._UserName; }
            set
            {
                if (value != this._UserName)
                {
                    this._UserName = value;
                    NotifyPropertyChanged("UserName");
                }
            }
        }
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
