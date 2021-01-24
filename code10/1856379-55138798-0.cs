    public static System.Data.DataTable MergeRowsToColumns(DataTable rowDataTable, string rowDataTableIdColumnName, string friendlyName, DataTable dataAllValue , string dataColumnValue , string  dataColumnKey)
            {
                List<string> columnsToAdd = new List<string>();
                if (rowDataTable == null)
                {
                    return null;
                }
                DataTable finalDataTable = new DataTable();
                finalDataTable.Columns.Add(friendlyName.ToLower());
                finalDataTable.Columns.Add(rowDataTableIdColumnName.ToLower());
    
                foreach (DataRow row in dataAllValue.Rows)
                {
                    if (row[rowDataTableIdColumnName].ToString() == rowDataTableIdColumnName.ToString())
                    {
                        continue;
                    }
                    else
                    {
                        var isExistColumnValue = columnsToAdd.Where(c => c == row[dataColumnKey].ToString()).FirstOrDefault();
                        if(isExistColumnValue == null)
                        {
                            columnsToAdd.Add(row[dataColumnKey].ToString());
                            finalDataTable.Columns.Add(row[dataColumnKey].ToString());
                        }
                    }
                }
                
                foreach (DataRow row in rowDataTable.Rows)
                {
                    DataRow newRow = finalDataTable.NewRow();
                    newRow[rowDataTableIdColumnName] = row[rowDataTableIdColumnName];
                    newRow[friendlyName] = row[friendlyName];
                    foreach (DataRow columnRows in dataAllValue.Rows)
                    { 
                        if(row[rowDataTableIdColumnName].ToString() != columnRows[rowDataTableIdColumnName].ToString())
                        {
                            continue;
                        }
                        var columnName = columnRows[dataColumnKey].ToString();
                        var columnValue = columnRows[dataColumnValue].ToString();
                        newRow[columnName] = columnValue; 
                    }
                    finalDataTable.Rows.Add(newRow);
                }
                return finalDataTable;
            }
