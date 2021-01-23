    Improving on  @vanessa
    
    public DataSet SplitDataTable(DataTable tableData, int max)
            {
                int i = 0;
                int j = 1;
                int countOfRows = tableData.Rows.Count;
                DataSet newDs = new DataSet();
                DataTable newDt = tableData.Clone();
                newDt.TableName = tableData.TableName+"_" + j;
                newDt.Clear();
                foreach (DataRow row in tableData.Rows)
                {
                    DataRow newRow = newDt.NewRow();
                    newRow.ItemArray = row.ItemArray;
    
                    newDt.Rows.Add(newRow);
                    i++;
                    
                    countOfRows--;
    
                    if (i == max )
                    {
                        newDs.Tables.Add(newDt);
                        j++;
                        newDt = tableData.Clone();
                        newDt.TableName = tableData.TableName + "_" + j;
                        newDt.Clear();
                        i = 0;
                    }
    
                    if (countOfRows == 0 && i < max)
                    {
                        newDs.Tables.Add(newDt);
                        j++;
                        newDt = tableData.Clone();
                        newDt.TableName = tableData.TableName + "_" + j;
                        newDt.Clear();
                        i = 0;
                    }
                }
                return newDs;
            }
