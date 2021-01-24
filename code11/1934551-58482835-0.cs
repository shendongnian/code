    public class MainPageViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
     
        public MainPageViewModel()
        {
            loadData();        
        }
    
        private void loadData()
        {
            Items = new ObservableCollection<Item>();
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
