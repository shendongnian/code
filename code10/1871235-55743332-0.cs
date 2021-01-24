            dbClassTables showTab = new dbClassTables();
        private void QueryView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexOfRow = e.RowIndex;
            DataGridViewRow selectedRow = QueryView.Rows[indexOfRow];
            DataTable dt1 = showTab.Select(selectedRow.Cells[2].Value.ToString());
            QueryView.DataSource = dt1;
        }
