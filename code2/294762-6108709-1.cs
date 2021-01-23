        public void SetGridColumnProperty(DataGridView grid, string columnName, string propertyName, object propertyValue)
        {
            DataGridViewColumn dgvColumn = grid.Columns[columnName];
            typeof(DataGridViewColumn).GetProperty(propertyName).SetValue(dgvColumn, propertyValue, null);
        }
