    private void myDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex > -1 && e.ColumnIndex > -1) // A row and cell was selected
        {
            var packet = myDataGrid.Rows[e.RowIndex].DataBoundItem as Packet;
            if (packet != null)
            {
                // Display packet information
            }
        }
    }
