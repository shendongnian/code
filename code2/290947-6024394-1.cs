    namespace Sample.ViewModels
    {
        public class ConnectedSystemViewModel : PropertyChangedBase
        {
            private string _name;
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    NotifyOfPropertyChange(() => Name);
                }
            }
    
            private string _description;
            public string Description
            {
                get { return _description; }
                set
                {
                    _description = value;
                    NotifyOfPropertyChange(() => Description);
                }
            }
        }
    }
