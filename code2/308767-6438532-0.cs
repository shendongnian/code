    void dataGridView1_CellFormatting(object sender,
                                      DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.RowIndex == 0)
        {
            // if the underlying type is int
            int value;
            if(e.Value != null && int.TryParse(e.Value.ToString(), out value))
            {
                e.Value = value.ToString("#k");
                /*** OR ***
                e.Value = value;
                e.CellStyle.Format = "#k";
                */
            }
        }
    }
