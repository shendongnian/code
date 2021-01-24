    public class StartViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ImageSource _imageSource = "";
        public ImageSource ImgSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;                
                OnPropertyChanged("ImgSource");
            }
        }
        public StartViewModel()
        {
            ImgSource = "pink.jpg";
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
