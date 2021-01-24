    public Form1()
    {
        InitializeComponent();
        // Set interval 10s
        this.myTimer = new System.Timers.Timer(10000);
        this.myTimer.Elapsed += new System.Timers.ElapsedEventHandler(myTimer_Elapsed);
        this.myTimer.AutoReset = true;
        this.myTimer.Enabled = true;
        this.myTimer.Start();
        chart1.Titles.Add("Line Chart");
        chart1.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;
        chart1.ChartAreas[0].Axes[1].MajorGrid.Enabled = false;
        myTimer.SynchronizingObject = this;
    }
    // Define a timer
    private System.Timers.Timer myTimer;
    private void myTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        // Call methond Refresh
        ChartRefresh();
        Console.WriteLine("refresh");
    }
    private void btLoadRawDate_Click(object sender, EventArgs e)
    {
        // Set the original data
        DataTable dt = new DataTable("cart");
        DataColumn dc1 = new DataColumn("name", Type.GetType("System.String"));
        DataColumn dc2 = new DataColumn("price", Type.GetType("System.Int16"));
        dt.Columns.Add(dc1);
        dt.Columns.Add(dc2);
        for (int i = 0; i < 10; i++)
        {
            DataRow dr = dt.NewRow();
            dr["name"] = i + 1;
            dr["price"] = i * 10;
            dt.Rows.Add(dr);
        }
        dataGridView1.DataSource = dt;
    }
    private void ChartRefresh()
    {
        // Traverse the DataGridView to get the data
        List<string> brand = new List<string>();
        List<int> price = new List<int>();
        for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
        {
            brand.Add(dataGridView1.Rows[row].Cells[0].Value == null ? "" : dataGridView1.Rows[row].Cells[0].Value.ToString());
            price.Add(dataGridView1.Rows[row].Cells[1].Value == null ? 0 : Convert.ToInt32(dataGridView1.Rows[row].Cells[1].Value));
        }
        chart1.Series.Clear();
        chart1.Series.Add("Price");
        chart1.Series["Price"].Points.DataBindXY(brand, brand);
        chart1.Series[0].ChartType = SeriesChartType.Column;
    }
