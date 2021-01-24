    DataTable dt4;
    DataTable conditionsData;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      dt4 = GetOriginalTable();
      FillOriginalTable(dt4);
      dataGridView1.DataSource = dt4;
    }
    private DataTable GetOriginalTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("ID", typeof(string));
      dt.Columns.Add("Work Order", typeof(string));
      dt.Columns.Add("Required By Date", typeof(DateTime));
      dt.Columns.Add("Close Date", typeof(DateTime));
      return dt;
    }
    private DataTable GetConditionsTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("Conditions", typeof(string));
      dt.Columns.Add("Counterr", typeof(int));
      return dt;
    }
    private void FillOriginalTable(DataTable originalDT) {
      originalDT.Rows.Add("1", "150", new DateTime(2019, 09, 19), new DateTime(2019, 09, 19));
      originalDT.Rows.Add("2", "151", new DateTime(2019, 09, 19), new DateTime(2019, 09, 21));
      originalDT.Rows.Add("3", "152", new DateTime(2019, 09, 19), new DateTime(2019, 09, 22));
      originalDT.Rows.Add("4", "153", new DateTime(2019, 09, 19));
      DataRow newRow = originalDT.NewRow();
      newRow["ID"] = "5";
      newRow["Work Order"] = "154";
      newRow["Close Date"] = new DateTime(2019, 09, 19);
      originalDT.Rows.Add(newRow);
    }
    private void show_data_Click(object sender, EventArgs e) {
      int close2 = 0;
      int closemorethan2 = 0;
      int execption = 0;
      DateTime date1;
      DateTime date2;
      TimeSpan diff;
      foreach (DataRow row in dt4.Rows) {
        if (row["Required By Date"].ToString() != "" && row["Close Date"].ToString() != "") {
          date1 = (DateTime)row["Close Date"];
          date2 = (DateTime)row["Required By Date"];
          diff = date1.Subtract(date2);
          if (diff.Days <= 2) {
            close2++;
          }
          else {
            closemorethan2++;
          }
        }
        else {
          execption++;
        }
      }
      conditionsData = GetConditionsTable();
      conditionsData.Rows.Add("Close in 2 Days", close2);
      conditionsData.Rows.Add("Close after 2 Days", closemorethan2);
      conditionsData.Rows.Add("Exceptions", execption);
      dataGridView2.DataSource = conditionsData;
    }
