    public class MainWindowModel
    {
        public MainWindowModel()
        {
            MovieLibrary = new ObservableCollection<Media>();
            //
            //Exmaple Fill
            //
            var m1 = new Media() { Title = "Breaking Bad", Episodes = new List<string> { "1", "2", "3", "4", "5", "6" } };
            var m2 = new Media() { Title = "The Big Bang Theory", Episodes = new List<string> { "1", "2", "3" } };
            m1.MediaChangedAction += OnMediaChanged;
            m2.MediaChangedAction += OnMediaChanged;
            MovieLibrary.Add(m1);
            MovieLibrary.Add(m2);
        }
        public ObservableCollection<Media> MovieLibrary { get; set; }
        
        private void OnMediaChanged(Media movie)
        {
            // do something
        }
    }
    public class Media
    {
        public event Action<Media> MediaChangedAction;
        public Media()
        {
        }
        public string Title { get; set; }
        public List<string> Episodes { get; set; }
        private string _progress;
        public string Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                MediaChangedAction?.Invoke(this);
            }
        }
    }
