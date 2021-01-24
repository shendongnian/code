    private DataTable dt;
    private void MyForm_Load()
    {
        LoadDefaults();
    }
    private void LoadDefaults()
    {
        dt.Columns.Add("Line", typeof(Int16));
        dt.Columns.Add("Section", typeof(string));
        dt.Columns.Add("Range", typeof(string));
        dt.Columns.Add("Total", typeof(float));
    }
    private void processButton_Click(object sender, EventArgs e)
    {
    foreach (var Item in mySplit) {
        dt.Rows.Add({Item.Trim(), ......});
        }
  
    this.DataGridView1.DataSource = dt;
    ...
    myChart.DataSource = dt;
    }
