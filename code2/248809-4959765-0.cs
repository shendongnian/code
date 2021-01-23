    StringBuilder sb = new StringBuilder();          
    foreach (DataColumn col in dt.Columns)         
    {             
        sb.Append(col.ColumnName + ',');         
    }          
    
    sb.Remove(sb.Length - 1, 1);         
    sb.AppendLine();          
    
    foreach (DataRow row in dt.Rows)         
    {             
        for (int i = 0; i < dt.Columns.Count; i++)             
        {                 
            sb.Append(row[i].ToString() + ",");             
        }              
    
        sb.AppendLine();         
    }          
    
    File.WriteAllText("test.csv", sb.ToString());
