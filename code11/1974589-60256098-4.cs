     public class MainViewModel : INotifyPropertyChanged
    {
        // Image
        private ImageSource _imageSource = "";
        public event PropertyChangedEventHandler PropertyChanged;
        public ImageSource ImgSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged("ImgSource");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public MainViewModel()
        {
            //SwapCMD = new CommandDelegate(action: x => { Console.WriteLine("Ignore this line"); }, executable: x => { return true; });
            ImgSource = new StartViewModel().ImgSource;
        }
    }
