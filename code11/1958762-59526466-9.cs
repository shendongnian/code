    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      DataTable dt = GetTable(16, 16);
      dataGridView1.DataSource = dt;
      dt = GetTable(10, 10);
      dataGridView2.DataSource = dt;
    }
    private DataTable GetTable(int totCol, int totRow) {
      DataTable dt = new DataTable();
      for (int i = 0; i < totCol; i++) {
        dt.Columns.Add("H " + (i + 1).ToString());
      }
      for (int i = 0; i < totRow; i++) {
        dt.Rows.Add(GetRowArray(totCol));
      }
      return dt;
    }
    private object[] GetRowArray(int size) {
      object[] obj = new object[size];
      for (int i = 0; i < size; i++) {
        obj[i] = (i + 1).ToString();
      }
      return obj;
    }
    private void button1_Click(object sender, EventArgs e) {
      save_datagridview(dataGridView1);
    }
    public void save_datagridview(DataGridView DGV) {
      string filename = @"D:\Test\datagridview.docx";
      Word.Application app = null;
      Word.Document doc = null;
      try {
        app = new Word.Application();
        //app.Visible = true;
        doc = app.Documents.Add();
        doc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
        Add_DGV_To_Doc(dataGridView1, doc);
        Add_DGV_To_Doc(dataGridView2, doc);
        SetHeadersForSections(doc);
        doc.SaveAs2(filename);
        MessageBox.Show("Document created successfully !");
      }
      catch (Exception e) {
        MessageBox.Show("ERROR: " + e.Message);
      }
      finally {
        if (doc != null) {
          Marshal.ReleaseComObject(doc);
        }
        if (app != null) {
          app.Quit();
          Marshal.ReleaseComObject(app);
        }
      }
    }
