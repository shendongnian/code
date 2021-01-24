    public class ViewModel
    {
        public ObservableCollection<ssearch> Items { get; } = new ObservableCollection<ssearch>();
        private static ViewModel _instance = new ViewModel();
        public static ViewModel Instance { get { return _instance; } }
    }
