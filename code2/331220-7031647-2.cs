    dataGridView1.CellFormatting +=
            new System.Windows.Forms.DataGridViewCellFormattingEventHandler(
            this.dataGridView1_CellFormatting);
    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Salary")
        {
            if (e.Value != null)
            {
                try
                {
                    e.Value = String.Format("Rs. {0:F2}", e.Value);
                    e.FormattingApplied = true;
                }
                catch (FormatException)
                {
                    e.FormattingApplied = false;
                }
            }
        }
    }
