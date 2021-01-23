    class TestAddRemoveCol
    {
        /// <summary>
        /// Adds the passed column to a datatable at a particular location
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="dc"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public DataTable AddCol(DataSet ds, string colName, Type type, int location)
        {
            DataTable dt = new DataTable();
            int colIndex = 0;
            DataColumn dc2 = null;
            foreach (DataColumn item in ds.Tables[0].Columns)
            {
                if (colIndex == location)
                {
                    dc2 = new DataColumn();
                    dc2.ColumnName = colName;
                    dc2.DataType = type;
                    
                    dt.Columns.Add(dc2);
                }
                dc2 = new DataColumn();
                dc2.ColumnName = item.ColumnName;
                dc2.DataType = item.DataType;
                dt.Columns.Add(dc2);
                colIndex++;
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dt.ImportRow(dr);
            }
            return dt;
        }
        /// <summary>
        /// returns a datacolumn with type string
        /// </summary>
        /// <param name="dc1"></param>
        /// <param name="newColName"></param>
        /// <returns></returns>
        public DataTable CopyCol(DataTable dt, string oldColName, string newColName)
        {
            DataTable dt2 = dt.Copy();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt2.Rows[i][newColName] = dt.Rows[i][oldColName].ToString();
            }
            
            return dt2;
        }
        /// <summary>
        /// Removes column from a particular location
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="index"></param>
        public void RemoveCol(DataTable dt, string colName)
        {
            //Remove column with a particular name
            dt.Columns.Remove(colName);
            //OR
            //Remove column at a particular index
            //ds.Tables[0].Columns.RemoveAt(index);
        }
    }
