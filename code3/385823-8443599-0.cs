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
    copy.DestinationTableName = "tNorthwind";
    copy.WriteToServer(dt);
  
    }
