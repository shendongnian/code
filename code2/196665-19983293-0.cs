    public static class DataTableExtensions
    {
        /// <summary>
        /// SetOrdinal of DataTable columns based on the index of the columnNames array. Removes invalid column names first.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columnNames"></param>
        /// <remarks> http://stackoverflow.com/questions/3757997/how-to-change-datatable-colums-order</remarks>
        public static void SetColumnsOrder(this DataTable dtbl, params String[] columnNames)
        {
            List<string> listColNames = columnNames.ToList();
            //Remove invalid column names.
            foreach (string colName in columnNames)
            {
                if (!dtbl.Columns.Contains(colName))
                {
                    listColNames.Remove(colName);
                }
            }
            foreach (string colName in listColNames)
            {
                dtbl.Columns[colName].SetOrdinal(listColNames.IndexOf(colName));
            }
    }
