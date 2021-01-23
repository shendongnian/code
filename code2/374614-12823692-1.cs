    public DataSet test(DataSet ds, int max)
        {
            int i = 0;
            int j = 1;
            DataSet newDs = new DataSet();
            DataTable newDt = ds.Tables[0].Clone();
            newDt.TableName = "Table_" + j;
            newDt.Clear();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                DataRow newRow = newDt.NewRow();
                newRow.ItemArray = row.ItemArray;
                newDt.Rows.Add(newRow);
                i++;
                if (i == max)
                {
                    newDs.Tables.Add(newDt);
                    j++;                    
                    newDt = ds.Tables[0].Clone();
                    newDt.TableName = "Table_" + j;
                    newDt.Clear();
                    i = 0;
                }
            }
            return newDs;
        }
