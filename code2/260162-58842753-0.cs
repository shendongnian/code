        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift || Control.ModifierKeys == Keys.Control)
            {
                if (_nSelectedColumn != 0)
                {
                    if (_nSelectedColumn != e.ColumnIndex)
                    {
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                        if (Control.ModifierKeys == Keys.Shift)
                            dataGridView.ClearSelection();
                    }
                }
                else
                    _nSelectedColumn = e.ColumnIndex;
            }
            else
                _nSelectedColumn = e.ColumnIndex;
        }
