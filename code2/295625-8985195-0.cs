    //...
        DialogResult dr = ofd.ShowDialog();
        if (dr == DialogResult.OK)
            {
                DataGridViewRow curRow = cell.DataGridView.Rows[cell.RowIndex];
                // check if the current row is the new row
                if (curRow.IsNewRow)
                {
                    // if yes, add a new one
                    int newRowIdx = cell.DataGridView.Rows.Add();
                    DataGridViewRow newRow = cell.DataGridView.Rows[newRowIdx];
                    DataGridViewCell newCell = newRow.Cells[cell.ColumnIndex];
                    // check if the new one is _not_ the new row (this is the unexpected behavior mentioned in the questions comments)
                    if (!newRow.IsNewRow)
                        newCell.Value = ofd.FileName;
                    else if (!curRow.IsNewRow)
                        cell.Value = ofd.FileName;
                }
                else {
                    cell.Value = ofd.FileName;
                }
            }
