    DataTable dt = new DataTable();
    
    string line = null;
    int i = 0;
    
    using (StreamReader sr = File.OpenText(@"c:\temp\table1.csv"))
    {  
          while ((line = sr.ReadLine()) != null)
          {
                string[] data = line.Split(',');
                if (data.Length > 0)
                {
                      if (i == 0)
                      {
                      foreach (var item in data)
                      {
                            dt.Columns.Add(new DataColumn());
                      }
                      i++;
                 }
                 DataRow row = dt.NewRow();
                 row.ItemArray = data;
                 dt.Rows.Add(row);
                 }
          }
    
          DataColumn col = new DataColumn("BatchId", typeof(System.Guid));
          col.DefaultValue = Guid.NewGuid();
          dt.Columns.Add(col);
    }
    
    
    using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConsoleApplication3.Properties.Settings.daasConnectionString"].ConnectionString))
    {
          cn.Open();
          using (SqlBulkCopy copy = new SqlBulkCopy(cn))
          {
                copy.ColumnMappings.Add(0, 0);
                copy.ColumnMappings.Add(1, 1);
                copy.ColumnMappings.Add(2, 2);
                copy.ColumnMappings.Add(3, 3);
                copy.ColumnMappings.Add(4, 4);
                copy.DestinationTableName = "Censis";
                copy.WriteToServer(dt);
          }
    } 
