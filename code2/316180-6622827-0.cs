    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.RowIndex != this.dataGridView1.NewRowIndex) //set your columnindex accordingly..
        {
            double d = double.Parse(e.Value.ToString());
            e.Value = string.Format(CultureInfo.CreateSpecificCulture("de-DE"), "{0:C}", d);
        }
    
    }
