    void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
        {
            DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
    
            cell.ErrorText =
                "Company Name must not be empty";
    
            if (cell.Tag == null)
            {
                cell.Tag = cell.Style.Padding;
                cell.Style.Padding = new Padding(0, 0, 18, 0);
            }
            e.Cancel = true;
                    
        }
        else
        {
            dataGridView1.Rows[e.RowIndex].ErrorText = string.Empty;
        }
    }
