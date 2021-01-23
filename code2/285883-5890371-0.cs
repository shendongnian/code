    public class MyVM : INotifyPropertyChanged
    {
        public string MyText
        {
            get
            {
                return _MyText;
            }
            set
            {
                if (value == _MyText)
                    return;
                _MyText = value;
                NotifyPropertyChanged("MyText");
            }
        }
        private string _MyText;
        public string MyTextTemp
        {
            get
            {
                return _MyTextTemp;
            }
            set
            {
                if (value == _MyTextTemp)
                    return;
                _MyTextTemp = value;
                NotifyPropertyChanged("MyTextTemp");
                NotifyPropertyChanged("IsTextDirty");
            }
        }
        private string _MyTextTemp;
        public bool IsTextDirty
        {
            get
            {
                return MyText != MyTextTemp;
            }
        }
        public bool IsMyTextBeingEdited
        {
            get
            {
                return _IsMyTextBeingEdited;
            }
            set
            {
                if (value == _IsMyTextBeingEdited)
                    return;
                _IsMyTextBeingEdited = value;
                if (!value)
                {
                    MyText = MyTextTemp;
                }
                NotifyPropertyChanged("IsMyTextBeingEdited");
            }
        }
        private bool _IsMyTextBeingEdited;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
