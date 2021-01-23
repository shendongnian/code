    public class MainViewModel
    {
        // ObservableCollection adds databinding goodness so when you add a new file,
        // the UI automatically refreshes
        public ObservableCollection<string> Images { get; private set; }
        public MainViewModel(string path)
        {
            Images = new ObservableCollection<string>();
            Images.AddRange(Directory.GetFiles(path, "*.jpg"));
        }
        public void AddImage(string path)
        {
            Images.Add(path);
        }
    }
