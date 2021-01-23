    public Form2(DataTable dtIt)
    {
        dtItems = dtIt;
        InitializeComponent();
    }
    private void AddEmptyRows()
    {
        for (int i = 1; i <= 5; i++)
        {
            dataGV.Rows.Add();
        }
    }
    private void Form2_Load(object sender, EventArgs e)
    {
        AddEmptyRows();
        for (int i = 0; i < dtItems.Rows.Count; i++) {
            dataGV.Rows[i].Cells[0].Value = dtItems.Rows[i]["city_ID"];
            dataGV.Rows[i].Cells[1].Value = dtItems.Rows[i]["city_Name"];
            dataGV.Rows[i].Cells[2].Value = dtItems.Rows[i]["status"];
            dataGV.Rows[i].Cells[3].Value = dtItems.Rows[i]["date"];
        }
        dataGV.Enabled = true;
    }
