    public class MySettings : INotifyPropertyChanged {
        private MySettings() {
        }
        private Visibility _labelShown;
        public Visibility LabelShown
        {
            get { return _labelShown; }
            set {
                _labelShown = value;
                // Raise PropertyChanged event for LabelShown
            }
        }
        private static MySettings _instance;
        public static MySettings Instance
        {
            get {
                if (_instance == null)
                    _instance = new MySettings();
                return _instance;
            }
        }
    }
