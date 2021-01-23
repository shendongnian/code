    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // ...
        private Color m_myColorProperty;
        public Color MyColorProperty
        {
            get
            {
                return m_myColorProperty;
            }
            set
            {
                m_myColorProperty = value;
                OnPropertyChanged("MyColorProperty");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void SwitchBackground()
        {
            if (MyColorProperty == Colors.Red)
            {
                MyColorProperty = Colors.Black;
            }
            else
            {
                MyColorProperty = Colors.Red;
            }
        }
    }
