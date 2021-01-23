    using System.ComponentModel;
    namespace Test.Model
    {
        public class User : INotifyPropertyChanged
        {
        //Private variables
        private string _username;
        private string _surname;
        private string _firstname;
        //Private - original holders
        private string _username_Orig;
        private string _surname_Orig;
        private string _firstname_Orig;
        private bool _isDirty;
        //Properties
        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                if (_username_Orig == null)
                {
                    _username_Orig = value;
                }
                _username = value;
                SetDirty();
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname_Orig == null)
                {
                    _surname_Orig = value;
                }
                _surname = value;
                SetDirty();
            }
        }
        public string Firstname
        {
            get { return _firstname; }
            set
            {
                if (_firstname_Orig == null)
                {
                    _firstname_Orig = value;
                }
                _firstname = value;
                SetDirty();
            }
        }
        public bool IsDirty
        {
            get
            {
                return _isDirty;
            }
        }
        public void SetToClean()
        {
            _username_Orig = _username;
            _surname_Orig = _surname;
            _firstname_Orig = _firstname;
            _isDirty = false;
            OnPropertyChanged("IsDirty");
        }
        private void SetDirty()
        {
            if (_username == _username_Orig && _surname == _surname_Orig && _firstname == _firstname_Orig)
            {
                if (_isDirty)
                {
                    _isDirty = false;
                    OnPropertyChanged("IsDirty");
                }
            }
            else
            {
                if (!_isDirty)
                {
                    _isDirty = true;
                    OnPropertyChanged("IsDirty");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
