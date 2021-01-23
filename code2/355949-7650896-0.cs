    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private GeoCoordinate _center;
        public GeoCoordinate Center
        {
            get { return _center; }
            set 
            {
                 if (_center == value) return;
                 _center = value;
                RaisePropertyChanged("Center"); }
            }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
