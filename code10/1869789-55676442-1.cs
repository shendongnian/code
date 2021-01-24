    private void selectAllChecksInDAtaGrid()
        {
            foreach (DataGridViewRow item in myDataGrid.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value) == false)
                {
                    item.Cells[0].Value = true;
                }
            }
        }
