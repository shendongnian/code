    string conn = string.Format(@"Data Source={0};Initial Catalog={1};User ID={2};Password={3}",
                "DATASOURCENAME", "DB", "USERNAME", "PASSWORD");
    
     Microsoft.SqlServer.Management.Smo.Server s = new Microsoft.SqlServer.Management.Smo.Server(
                        new Microsoft.SqlServer.Management.Common.ServerConnection(
                            new System.Data.SqlClient.SqlConnection(
                        conn)));
    
     Microsoft.SqlServer.Management.Smo.Database db =
                        s.Databases["YOUR_DATA_BASE_NAME"];
                    Microsoft.SqlServer.Management.Smo.Table tbl =
                        db.Tables[0];//Or you can get the table by table name
    
     List<Microsoft.SqlServer.Management.Smo.Column> autoIncrementClmns = 
                        new List<Microsoft.SqlServer.Management.Smo.Column>();
    
     foreach (Microsoft.SqlServer.Management.Smo.Column clmn in tbl.Columns)
      {
         if (clmn.IdentityIncrement > 0)//Check if this column is AutoIncrement
             autoIncrementClmns.Add(clmn);
      }
