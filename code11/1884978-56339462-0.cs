    public class TabViewModel
    {
        public string Header { get; set; }
        public DataTable Tablecontent { get; set; }
    }
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private ObservableCollection<TabViewModel> selectedtables;
        public ObservableCollection<TabViewModel> SelectedTables
        {
            get { return selectedtables; }
            set
            {
                if (selectedtables != value)
                {
                    selectedtables = value;
                    OnPropertyChanged("SelectedTables");
                }
            }
        }
    }
