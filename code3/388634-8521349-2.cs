    private string[] list;
    private DataSet ds;
    public frmMain()
    {
      InitializeComponent();
      ds = this.GetDataSet("SELECT deptName from empDept", "empDept");
      list = new string[ds.Tables[0].Rows.Count];
      comboBox1.AutoCompleteCustomSource.AddRange(list);
      comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
      comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
    }
    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      if (e.Control is ComboBox)
      {
        ComboBox cb = e.Control as ComboBox;
        cb.DropDownStyle = ComboBoxStyle.DropDown;
        
      }
    }
