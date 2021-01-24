    public class MainPageViewModel
    {
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();     
        public MainPageViewModel()
        {
            loadData();        
        }
    
        private void loadData()
        {
            using (var reader = new StreamReader("Assets\\Archive.csv", true))
            using (var csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<Item>();
                foreach (var item in records)
                {
                    Items.Add(item);
                }
            }
        }
    
        public ICommand BtnClickCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Items.RemoveAt(0);
                });
            }
        }
    
    }
