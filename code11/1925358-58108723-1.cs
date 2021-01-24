    DataTable GridTable;
    DataTable GridTable2;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      GridTable = GetTable();
      FillTable(GridTable);
      dataGridView1.DataSource = GridTable;
      GridTable2 = GetTable();
      FillTable(GridTable2);
      myDataGridView1.DataSource = GridTable2;
    }
    private DataTable GetTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("Col1", typeof(string));
      dt.Columns.Add("Col2", typeof(string));
      dt.Columns.Add("Col3", typeof(string));
      dt.Columns.Add("Col4", typeof(string));
      return dt;
    }
    private void FillTable(DataTable dt) {
      for (int i = 0; i < 15; i++) {
        dt.Rows.Add("C1R" + i, "C2R" + i, "C3R" + i, "C4R" + i);
      }
    }
    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
      if (e.Control is DataGridViewTextBoxEditingControl) {
        DataGridViewTextBoxEditingControl tb = e.Control as DataGridViewTextBoxEditingControl;
        tb.PreviewKeyDown -= dataGridView1_PreviewKeyDown;
        tb.PreviewKeyDown += dataGridView1_PreviewKeyDown;
      }
    }
    private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
      if (e.KeyData == Keys.Enter) {
        //if (dataGridView1.CurrentCell.IsInEditMode) {
          Point lastPosition = new Point(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);
          if (lastPosition.X == dataGridView1.ColumnCount - 1) {
            lastPosition.X = 0;
            lastPosition.Y++;
          }
          else {
            lastPosition.X++;
          }
          dataGridView1.CurrentCell = dataGridView1.Rows[lastPosition.Y].Cells[lastPosition.X];
        //}
        //else {
          // good luck here
        //}
      }
    }
