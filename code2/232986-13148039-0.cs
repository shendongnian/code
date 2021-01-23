        /// <summary>
        /// Returns true if the given DataTable has the given column name
        /// </summary>
        /// <param name="data">The DataTable you are checking</param>
        /// <param name="columnName">the column name you want</param>
        /// <returns></returns>
        public static bool HasColumn(DataTable data, string columnName)
        {
            if(data == null || string.IsNullOrEmpty(columnName))
            {
                return false;
            }
            foreach(DataColumn column in data.Columns) 
                 if (columnName.Equals(column.ColumnName, StringComparison.OrdinalIgnoreCase)) return true;
            return false;
        }
