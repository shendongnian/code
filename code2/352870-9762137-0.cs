        private void dgvServerList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    string id = dgvServerList[e.ColumnIndex, e.RowIndex].Value.ToString();
                    int duplicaterow = 0;
                    for (int row = 0; row < dgvServerList.Rows.Count; row++)
                    {
                        if (row != e.RowIndex && id == dgvServerList[e.ColumnIndex, row].Value.ToString())
                        {
                            duplicaterow = row + 1;
                            MessageBox.Show("Duplicate found in the row: " + duplicaterow);
                            this.dgvServerList[e.ColumnIndex, e.RowIndex].Value = "";
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
        }
