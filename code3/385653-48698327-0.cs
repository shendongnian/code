        private bool FindInGrid(string search)
        {
            bool results = false;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.DataBoundItem != null)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value.ToString().Contains(search))
                        {
                            dgvData.CurrentCell = cell;
                            dgvData.FirstDisplayedScrollingRowIndex = cell.RowIndex;
                            results = true;
                            break;
                        }
                        if (results == true)
                            break;
                    }
                    if (results == true)
                        break;
                }
            }
            return results;
        }
