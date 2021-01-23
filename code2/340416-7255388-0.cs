            DataSet dsData = new DataSet();
            List<DataRow> rowsToDelete = new List<DataRow>();
            foreach (DataRow row in dsData.Tables["Table1"].Rows)
            {
                if (item.SubItems[2].Text == row["LoginName"].ToString())
                {
                    rowsToDelete.Add(row);
                }
            }
            foreach(DataRow row in rowsToDelete)
            {
                dsData.Tables["Table1"].Rows.Remove(row); 
            }
