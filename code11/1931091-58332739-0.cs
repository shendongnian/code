        public LotScan()
        {
            InitializeComponent();
            gridLotData.ItemsSource = LotDataList;
        }
        private LotData LoadCollectionData()
        {
            return new LotData()
            {
                Lot = LotNo.Text,
                Description = frmDescription.Text,
                PO = int.Parse(frmPO.Text),
                MfgPart = frmMfgPart.Text,
            };
        }
        public class LotData
        {
            public string Lot;
            public string Description { get; set; }
            public int PO { get; set; }
            public string MfgPart { get; set; }
        }
        public ObservableCollection<LotData> LotDataList = new ObservableCollection<LotData>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LotDataList.Add(LoadCollectionData());
            LotNo.Text = String.Empty;
            frmMfgPart.Text = string.Empty;
            frmDescription.Text = String.Empty;
            frmMfgPart.Text = string.Empty;
            frmPO.Text = string.Empty;
        }
