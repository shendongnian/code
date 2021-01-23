    foreach (DataRow drRow in ds.Tables[0].Rows)
    
        {
            for(int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                int rowValue;
        
                if (int.TryParse(drRow[i].ToString(), out rowValue))
                {
                    if (rowValue == 0)
                    {
                        drRow[i] = null;
                    }
                }
                           
            }
        }
