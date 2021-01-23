    public DataSet test(DataSet ds, int max)
        {
            int i = 0;
            DataSet newDs = new DataSet();
            DataTable newDt = ds.Tables[0].Clone();
            newDt.Clear();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                newDt.Rows.Add(row);
                i++;
                if (i == max)
                {
                    newDs.Tables.Add(newDt);
                    newDt = ds.Tables[0].Clone();
                    newDt.Clear();
                    i = 0;
                }
            }
            return newDs;
        }
