     private void Form1_Load(object sender, EventArgs e)
            {
                DataGridViewLinkColumn col1 = new DataGridViewLinkColumn();
                dataGridView1.Columns.Add(col1);
                dataGridView1.Columns[0].Name = "Links";
    
                DataGridViewRow dgvr = new DataGridViewRow();
                dgvr.CreateCells(dataGridView1);
    
                DataGridViewCell linkCell = new DataGridViewLinkCell();
                linkCell.Value = @"http:\\www.google.com";
                dgvr.Cells[0] = linkCell;
    
                dataGridView1.Rows.Add(dgvr);
            }
    
            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewLinkColumn && !(e.RowIndex == -1))
                {
                    Process.Start(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
