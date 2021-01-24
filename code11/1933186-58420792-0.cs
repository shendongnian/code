    private const string strConn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Matthew\\QCast.mdf;Integrated Security=True;Connect Timeout=30";
    private ObservableCollection<LotData> lot = new ObservableCollection<LotData>();
    public Window1()
    {
        InitializeComponent();
        // Bind ItemsSource once
        gridLotData.ItemsSource = lot;
    }
    public void AddDataToGrid_Click(object sender, RoutedEventArgs e)
    {
        // Read data from form and add to collection
        lot.Add(new LotData()
        {
            Lot = LotNo.Text,
            Description = frmDescription.Text,
            PO = int.Parse(frmPO.Text),
            MfgPart = frmMfgPart.Text,
        });
        // Clear entry fields
        LotNo.Text = String.Empty;
        frmMfgPart.Text = string.Empty;
        frmDescription.Text = String.Empty;
        frmMfgPart.Text = string.Empty;
        frmPO.Text = string.Empty;
    }
        
    private void WriteCollectionToDb_Click(object sender, RoutedEventArgs e)
    {
        using (var conn = new SqlConnection(strConn))
        {
            conn.Open();
            try
            {
                foreach (var lotData in lot)
                {
                    using (var command = new SqlCommand("INSERT into LotData Values (@LotNum)", conn))
                    {
                        command.Parameters.Add("LotNum", lotData.Lot);
                        command.ExecuteNonQuery();
                    }
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }
