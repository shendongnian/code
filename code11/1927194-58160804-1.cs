    public class MainViewModel : ViewModelBase
    {
        public RelayCommand ViewLoadedCommand { get; private set; }
        public MainViewModel()
        {
            ViewLoadedCommand = new RelayCommand(SaveEntry);
        }
    
       
        private void SaveEntry()
        {
            // save entry.
        }
    }
