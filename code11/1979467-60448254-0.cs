        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ReLink(e.ColumnIndex ,e.RowIndex);
        }
        private void dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ReLink(e.ColumnIndex ,e.RowIndex);
        }
        //no matter which event I will specify, it is clear that it will only work for one event
        private void ReLink(int colIndex, int rowIndex)
        {
            if (colIndex >= 0 && rowIndex >= 0 && dgv.Rows[rowIndex].Cells[colIndex] is DataGridViewLinkCell)
            { Process.Start(dgv.Rows[rowIndex].Cells[colIndex].Value as string); }
        }
