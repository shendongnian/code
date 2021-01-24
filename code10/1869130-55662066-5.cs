    DataTable GridTable;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      GridTable = GetTable();
      FillTable(GridTable);
      AddDifferenceColumn(GridTable);
      CalculateDateDif(GridTable);
      dataGridView1.DataSource = GridTable;
      dataGridView1.Columns[3].Width = 180;
    }
    private DataTable GetTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("ID", typeof(string));
      dt.Columns.Add("Name", typeof(string));
      dt.Columns.Add("ExpireDate", typeof(DateTime));
      return dt;
    }
    private void AddDifferenceColumn(DataTable dt) {
      dt.Columns.Add("TimeToExpire", typeof(string));
    }
    private void FillTable(DataTable dt) {
      dt.Rows.Add("ID1", "Name1", new DateTime(2019, 12, 31));
      dt.Rows.Add("ID2", "Name2", new DateTime(2019, 8, 31));
      dt.Rows.Add("ID3", "Name3", new DateTime(2019, 4, 30));
      dt.Rows.Add("ID4", "Name4", new DateTime(2019, 1, 31));
      dt.Rows.Add("ID5", "Name5", new DateTime(2019, 4, 12, 21, 38, 00));
    }
    private void CalculateDateDif(DataTable dt) {
      foreach (DataRow row in dt.Rows) {
        SetDifCol(row);
      }
    }
    private void SetDifCol(DataRow row) {
      TimeSpan dif = ((DateTime)row["ExpireDate"]).Subtract(DateTime.Now);
      row["TimeToExpire"] = dif.Days + " days " + dif.Hours + " hours " + dif.Minutes + " minutes";
    }
    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
      if (dataGridView1.Columns[e.ColumnIndex].Name == "ExpireDate") {
        if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["ExpireDate"].Value != null) {
          DataRowView row = (DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem;
          SetDifCol(row.Row);
        }
      }
    }
    
