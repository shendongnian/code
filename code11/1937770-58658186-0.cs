        private void origDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string[] rowData = new string[origDgv.Columns.Count];
            int iOffset = 0;
            foreach (DataGridViewCell dgvCell in origDgv.Rows[e.RowIndex].Cells)
            {
                if(dgvCell.EditedFormattedValue != null)
                {
                    rowData[iOffset] = dgvCell.EditedFormattedValue.ToString();
                    
                }
                iOffset++;
            }
            copyDgv.Rows.Add(rowData);
        }
