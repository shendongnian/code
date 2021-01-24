        private void Button1_Click(object sender, EventArgs e)
        {
            var columnIndex = 1;
            var dataGrid = new DataGridView();
            var index = GetFirstEmptyCellByColumnIndex(dataGrid, columnIndex);
            dataGrid[columnIndex, index].Value = "new value";
        }
        private int GetFirstEmptyCellByColumnIndex(DataGridView dataGrid, int columnIndex)
        {
            var index = -1;
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (string.IsNullOrEmpty((string)row.Cells[columnIndex].Value))
                {
                    index = row.Index;
                    break;
                }
            }
            return index != -1
                ? index
                : dataGrid.Rows.Add();
        }
