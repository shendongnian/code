    private void DataGridView1_CellFormatting(object sender,
                                              DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == yourIndexOrName1 && e.Value != null)
        {
            var s = e.Value as string[];
            e.Value = String.Join(", ", s);
        }
    }
