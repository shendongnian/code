      System.Data.Sql.SqlDataSourceEnumerator instance = System.Data.Sql.SqlDataSourceEnumerator.Instance;
      System.Data.DataTable dataTable = instance.GetDataSources();
      foreach (System.Data.DataRow row in dataTable.Rows)
      {
          Console.WriteLine(row["ServerName"] + "\\" + row["InstanceName"]);
      }
