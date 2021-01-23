    using System.ComponentModel;
    
    class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private bool _enableCheckBox;
        public bool EnableCheckBox
        {
            get { return _enableCheckBox }
            set 
            {
                _enableCheckBox = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("EnableCheckBox"));
            }
        }
    }
