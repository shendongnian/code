        public class UtilityListModel : INotifyPropertyChanged
        {
            public ObservableCollection<ShopDet> Items { get; set; } = new ObservableCollection<ShopDet>();
            public List<ShopDet> YourItemList { get; set; }
            public string LeaseName { get; set; }
            public string LeaseDate { get; set; }
            public string LeaseNo { get; set; }
            private bool _expanded;
            public UtilityListModel()
            {
                PopulateItems();
            }
            private void PopulateItems()
            {
                //STEP 1. pupulate your YourItemList with another method probably
                //STEP 2. add items to your ObservableCollection
            }
            public void SearchItems(string searchText)
            {
                //Call this method to select items from YourItemsList
                var searchResult = YourItemList.Where(....).ToList();
                //Clear items in your ObservableCollection Items
                Items.Clear();
                //Add selected items to your ObservableCollection the viewmodel will handle listview update
                foreach (var item in searchResult) // example you can also cast it.
                {
                    Items.Add(item);
                }
            }
            public string TitleWithItemCount
            {
                get { return string.Format("{0} {1} {2}", LeaseName, LeaseDate, LeaseNo); }
            }
            public bool Expanded
            {
                get { return _expanded; }
                set
                {
                    if (_expanded != value)
                    {
                        _expanded = value;
                        OnPropertyChanged("Expanded");
                        OnPropertyChanged("StateIcon");
                    }
                }
            }
            public string StateIcon
            {
                get { return Expanded ? "twoArrowup.png" : "twoArrowdown.png"; }
            }
            public UtilityListModel(string leasename, string leaseno, string leasedate, bool expanded = true)
            {
                LeaseName = leasename;
                LeaseNo = leaseno;
                LeaseDate = leasedate;
                Expanded = expanded;
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public class ShopDet
        {
            public string ShopName { get; set; }
            public string ShopDate { get; set; }
            public string MallName { get; set; }
            public string MallPlace { get; set; }
            public string MallProduct { get; set; }
            public string MallUnitNo { get; set; }
            public string TimePeriod { get; set; }
            public string UtilityType { get; set; }
            public string StartReading { get; set; }
            public string EndReading { get; set; }
            public string UnitConsumed { get; set; }
            public string UnitRate { get; set; }
            public List<ShopDet> MallDetails { get; set; }
            public List<ShopDet> MeterDetails { get; set; }
            public List<ShopDet> ShopDetails { get; set; }
        }
    }
