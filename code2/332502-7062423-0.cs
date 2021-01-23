    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // Check if it's Persian Date Column
        if (this.dataGridView1.Columns[e.ColumnIndex].Name == "PersianDate") //PersianDate == Your Date Column Name
        {
            if (e.Value != null)
            {
                 e.Value = ToGregorianDate(e.Value);
    
            }
        }
    }
