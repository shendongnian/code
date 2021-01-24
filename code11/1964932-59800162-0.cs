    public class MainWindowViewModel
    {
        public ICommand LoadGridCommand { get; }
        public ObservableCollection<Author> Authors { get; }
            = new ObservableCollection<Author>();
        public MainWindowViewModel()
        {
            LoadGridCommand = new RelayCommand(LoadGrid, null);
        }
        private void LoadGrid(object parameter)
        {
            // Authors.Clear();
            // Authors.Add(...);
        }
    }
