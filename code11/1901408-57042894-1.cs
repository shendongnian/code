    public class Item
    {
        public string fieldname
        {
            get;
            set;
        }
        public string datebegin
        {
            get;
            set;
        }
        public string dateend
        {
            get;
            set;
        }
        public string progression
        {
            get;
            set;
        }
        public Item(int number)
        {
            fieldname = "Filed name " + number;
            datebegin = "12-12-12";
            dateend = "14-12-12";
            progression = (5 * number).ToString();
        }
    }
    public class ViewModel
    {
        public ICollection<Item> Items
        {
            get;
            private set;
        }
        public ViewModel()
        {
            Items = new ObservableCollection<Item>();
        }
        public ICommand Add
        {
            get
            {
                return new RelayCommand((a) =>
                {
                    Items.Add(new Item(Items.Count));
                });
            }
        }
    }
