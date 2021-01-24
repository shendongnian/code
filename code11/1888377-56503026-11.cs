    DataTable GridTable;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      GridTable = GetTable();
      FillTable(GridTable);
      dataGridView1.Columns.Add(GetComboColumn());
      dataGridView1.DataSource = GridTable;
    }
    private DataTable GetTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("Col0", typeof(string));
      dt.Columns.Add("Dates", typeof(DateTime));
      return dt;
    }
    private DataGridViewComboBoxColumn GetComboColumn() {
      DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
      comboCol.DataPropertyName = "Dates";
      comboCol.HeaderText = "Dates";
      comboCol.DisplayMember = "StringDateTime";
      comboCol.ValueMember = "DateTime";
      comboCol.Width = 175;
      DataTable comboData = GetComboDates();
      comboCol.DataSource = comboData;
      return comboCol;
    }
    private void FillTable(DataTable dt) {
      for (int i = 0; i < 10; i++) {
        dt.Rows.Add("C0R" + i);
      }
    }
    private DataTable GetComboTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("DateTime", typeof(DateTime));
      dt.Columns.Add("StringDateTime", typeof(string));
      return dt;
    }
    private DataTable GetComboDates() {
      DataTable dt = GetComboTable();
      Random rand = new Random();
      int duration = 5 * 365;          
      DateTime randomDate = DateTime.Today.AddDays(-rand.Next(duration));
      for (int i = 0; i < 10; i++) {
        dt.Rows.Add(randomDate, String.Format("{0:yyyy/MM/dd - hh:mm:ss tt}", randomDate));
        randomDate = DateTime.Today.AddDays(-rand.Next(duration));
      }
      return dt;
    }
