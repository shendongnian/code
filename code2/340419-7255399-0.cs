    for (int i = 0; i < dsData.Tables["Table1"].Rows.Count; i++)
      {
         DataRow row = dsData.Tables["Table1"].Rows[i];
         if (item.SubItems[2].Text == row["LoginName"].ToString())            
           {             
             dsData.Tables["Table1"].Rows.Remove(row); //<- main code of interest
           }
      }
