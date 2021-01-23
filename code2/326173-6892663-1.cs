    dataGridView1.CellFormatting += dataGridView1_CellFormatting;
    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {            
        if (dataGridView1.Columns[e.ColumnIndex].Name == "ImageColumnName")
        {
            if (collection[e.RowIndex].Result)
            {
                e.Value = (System.Drawing.Image)Properties.Resources.Check;
            }
            else
            {
                e.Value = (System.Drawing.Image)Properties.Resources.Cancel;
            }
        }
    }
