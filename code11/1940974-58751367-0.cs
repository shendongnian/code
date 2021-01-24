    foreach (DataRow row in ds.Tables[0].Rows)
        {
          foreach (DataColumn col in ds.Tables[0].Columns)
          {
             string colName = col.ToString();
             if (colName.Contains("columnAmlooking"))
               row[columnAmlooking] = "inputvalue";
           }
        }
