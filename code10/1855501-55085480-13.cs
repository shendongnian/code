    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (this.dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "Date 1")
            try
            {
                var EMIDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["date1DataGridViewTextBoxColumn"].Value);
                if (EMIDate <= DateTime.Today)
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
            catch
            {
            }
    }
