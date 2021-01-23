            public void MoveDataRowTo(DataRow dataRow,int destination)
            {
                DataTable parentTable = dataRow.Table;
                int rowIndex = parentTable.Rows.IndexOf(dataRow);
    
                if (rowIndex > 0)
                {
                    DataRow newDataRow = parentTable.NewRow();
    
                    for (int index = 0; index < dataRow.ItemArray.Length; index++)
                        newDataRow[index] = dataRow[index];
    
                    parentTable.Rows.Remove(dataRow);   
                    parentTable.Rows.InsertAt(newDataRow, destination);
    
                    dataRow = newDataRow;
                }
            }
