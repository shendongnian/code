    public NewRecord()
    {
        InitializeComponent();
        List<string> ledgerList = new List<string>();
        ledgerList = DAL_LedgerNameList.LoadLedgers();
        if (ledgerList.Length==0) 
        {
            sellerText.ItemsSource = new string() {"No Sellers Exist"}
        }
        else
        {
            sellerText.ItemsSource = ledgerList;
        }
    }
