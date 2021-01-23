       DataTable DT = dBQuery.GetInfo();
       for (int i = 0; i < result.Rows.Count; i++) 
           {          
               zonecd.Items.Add(result.Rows[i].ItemArray[0].ToString()); 
           }
