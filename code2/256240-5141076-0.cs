<Code>
 public class ImageData : INotifyPropertyChanged, IDisposable
    {
        private string _id;
        private string _imagePath;
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }
        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }
        public void Dispose()
        {
          //Do dispose of resources.
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class YourViewModel : INotifyPropertyChanged, IDisposable
    {
        private ObservableCollection<ImageData> _images;
        public ObservableCollection<ImageData> Images
        {
            get
            {
                return _images;
            }
            set
            {
                _images = value;
                OnPropertyChanged("Images");
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void Dispose()
        {
            Images = null;
        }
    }
</Code>
