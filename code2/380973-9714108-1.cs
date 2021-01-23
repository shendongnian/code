        class UserAlertViewModel : BaseViewModel
    {
        private readonly UserAlert _alertItem;
        public UserAlertViewModel()
        {
            _alertItem = new UserAlert();
        }
        public UserAlertViewModel(UserAlert alertItem)
        {
            _alertItem = alertItem;
        }
        public int Node_id
        {
            get { return _alertItem.Node_id; }
            set { _alertItem.Node_id = value; OnPropertyChanged("Node_id"); }
        }
        public double Threshold
        {
            get { return _alertItem.Threshold; }
            set { _alertItem.Threshold = value; OnPropertyChanged("Threshold"); }
        }
        public string TypeOfAlert
        {
            get { return _alertItem.TypeOfAlert; }
            set { _alertItem.TypeOfAlert = value; OnPropertyChanged("TypeOfAlert"); }
        }
    }
