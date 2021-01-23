    public static string ToCSV(DataTable dataTable)
        {
            //create the stringbuilder that would hold the data
            StringBuilder sb = new StringBuilder();
            //check if there are columns in the datatable
            if (dataTable.Columns.Count != 0)
            {
                //loop thru each of the columns for headers
                foreach (DataColumn column in dataTable.Columns)
                {
                    //append the column name followed by the separator
                    sb.Append(column.ColumnName + ",");
                }
                //append a carriage return
                sb.Append("\r\n");
    
                //loop thru each row of the datatable
    
                foreach (DataRow row in dataTable.Rows)
                {
                    //loop thru each column in the datatable
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        //get the value for the row on the specified column
                        // and append the separator
                        sb.Append("\"" + row[column].ToString() + "\"" + ",");
                    }
                    //append a carriage return
                    sb.Append("\r\n");
                }
            }
            return (sb.ToString());
        }
