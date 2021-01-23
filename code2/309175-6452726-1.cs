    for (int i = 0; i < dataGridView1.RowCount; i++)
    {
        if (!dataGridView1.Rows[i].IsNewRow)
        {
            for (int j = 0; j < dataGridView1.ColumnCount; j++)
            {        
                DataGridViewCell cell = dataGridView1[j, i];
                MessageBox.Show(cell.FormattedValue.ToString());                    
            }
        }
    }
