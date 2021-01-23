      public Form1()
      {
         InitializeComponent();
         dataGridView1.Columns.Add("ColumnA", "ColumnA");
         dataGridView1.Columns.Add("ColumnB", "ColumnB");
         dataGridView1.Rows.Add(new[] {"1colA", "1colB"});
         dataGridView1.Rows.Add(new[] { "2colA", "2colB" });
      }
      private void button1_Click(object sender, EventArgs e)
      {
         foreach (DataGridViewRow row in dataGridView1.SelectedRows)
         {
            dataGridView1.Rows.Remove(row);
         }
         dataGridView1.Invalidate();
      }
