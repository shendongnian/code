    int specificColumnIndex = 5;
    const string FUJIUNIV = "FUJI/UNIVERSAL";
    const Color cFUJIBACK = Color.Yellow;
    const Color cFUJITEXT = Color.Black;
    public Form1() {
      InitializeComponent();
      dataGridView1.Paint += new PaintEventHandler(DataGridView_Paint);
    }
    private void DataGridView_Paint(object sender, PaintEventArgs e) {
      foreach (DataGridViewRow row in dataGridView1.Rows) {
        if (row.Cells[specificColumnIndex].Value.ToString() == FUJIUNIV) {
          foreach (DataGridViewCell cell in row.Cells) {
            cell.Style.BackColor = cFUJIBACK;
            cell.Style.ForeColor = cFUJITEXT;
            cell.Style.SelectionBackColor = Color.Gold;
          }
        }
      }
    }
  }
