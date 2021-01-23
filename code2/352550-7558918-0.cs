        public class Model_Sport : INotifyPropertyChanged
        {
            #region  Constructor
            public Model_Sport(string name, ICommand command)
            {
                Name = name;
                SportsResponseCommand = command;
            }
            #endregion
            static readonly PropertyChangedEventArgs _NameEventArgs = new PropertyChangedEventArgs("Name");
            private string _Name = null;
            public string Name
            {
                get { return _Name; }
                set
                {
                    _Name = value;
                    OnPropertyChanged(_NameEventArgs);
                }
            }
            static readonly PropertyChangedEventArgs _SportsResponseCommandEventArgs = new PropertyChangedEventArgs("SportsResponseCommand");
            private ICommand _SportsResponseCommand = null;
            public ICommand SportsResponseCommand
            {
                get { return _SportsResponseCommand; }
                set
                {
                    _SportsResponseCommand = value;
                    OnPropertyChanged(_SportsResponseCommandEventArgs);
                }
            }
            static readonly PropertyChangedEventArgs _IsCheckedEventArgs = new PropertyChangedEventArgs("IsChecked");
            private bool _IsChecked = false;
            public bool IsChecked
            {
                get { return _IsChecked; }
                set
                {
                    _IsChecked = value;
                    OnPropertyChanged(_IsCheckedEventArgs);
                }
            }
            #region INotifyPropertyChanged Members
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, eventArgs);
                }
            }
            #endregion
        }
