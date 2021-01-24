    public Form1() {
      InitializeComponent();
      dataGridView1.Columns[0].Name = "ConditionColumn";
      dataGridView1.Columns[0].HeaderText = "Condition";
      dataGridView1.Columns[2].Name = "HideColumn";
      dataGridView1.Columns[2].HeaderText = "Hide Column";
    }
    private void Form1_Load(object sender, EventArgs e) {
      FillGrid();
    }
    private void FillGrid() {
      for (int i = 0; i < 20; i++) {
        dataGridView1.Rows.Add(i, "C1R" + i, "C2R" + i, "C3R" + i);
      }
    }
