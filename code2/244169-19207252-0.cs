    da.Fill(dtusers);
 
    dataGridView1.DataSource = dtusers;
    // dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
    dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
