    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> Images { get; }
            = new ObservableCollection<string>();
        private string selectedImage;
        public string SelectedImage
        {
            get { return selectedImage; }
            set
            {
                selectedImage = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedImage)));
            }
        }
    }
