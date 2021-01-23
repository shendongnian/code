        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.SelectedCells.Count > 0) // Checking to see if any cell is selected
            {
                int mSelectedRowIndex = dgvProducts.SelectedCells[0].RowIndex;
                DataGridViewRow mSelectedRow = dgvProducts.Rows[mSelectedRowIndex];
                string mCatagoryName = Convert.ToString(mSelectedRow.Cells[1].Value);
                SomeOtherMethod(mProductName); // Passing the name to where ever you need it
                this.close();
            }
        }
