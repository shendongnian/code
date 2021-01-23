        void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Make sure it is a left click
            if(e.Button == MouseButtons.Left)
            {
                // Make sure it is on a cell
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    // Only allow certain columns to trigger selection changes (1 & 2)
                    if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                    {
                        // Set my own private selected row index
                        setSelectedRow(e.RowIndex);
                    }
                    else
                    {
                        // Actions for other columns...
                    }
                }
            }
        }
