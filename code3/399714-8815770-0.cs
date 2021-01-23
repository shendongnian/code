    public class ViewModel
    {
        public ViewModel()
        {
            Accounts = new ObservableCollection<string>();
        }
    
        public ObservableCollection<string> Accounts { get; set; }
    }
