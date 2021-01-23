    void Form1_Load(object sender, EventArgs e)
    {
       for (int i = 0; i < dataGridView1.Columns.Count; i++)
       {
          dataGridView1.AutoResizeColumn(
             i, DataGridViewAutoSizeColumnMode.ColumnHeader);
       }
    }
