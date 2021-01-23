    public class MySettings : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(sting s)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(s);
            }
        }
    }
    public class BoolSettings : MySettings
    {
        bool _value;
        bool BoolSetting
        {
            get { return _value; }
            set
            {
                if(_value != value)
                {
                    _value = value;
                    OnPropertyChanged("BoolSetting");
                }
             }
        }
    }
