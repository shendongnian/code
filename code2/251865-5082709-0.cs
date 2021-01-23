        /// <summary>
        /// Gets a list of the DataRow objects that are the datasources for a DataGridViews selected rows
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static DataRow[] GetSelectedDataRows(DataGridView grid)
        {   
            DataRow[] dRows = new DataRow[grid.SelectedRows.Count];
            for (int i = 0; i < grid.SelectedRows.Count; i++)
                dRows[i] = ((DataRowView)grid.SelectedRows[i].DataBoundItem).Row;
            return dRows;  
        }
        /// <summary>
        /// move row from one grid to another
        /// </summary>
        public void MoveRows(DataTable src, DataTable dest, DataRow[] rows)
        {
            foreach (DataRow row in rows)
            {   
                // add to dest
                dest.Rows.Add(row.ItemArray);
                // remove from src
                src.Rows.Remove(row);
            }
        }
