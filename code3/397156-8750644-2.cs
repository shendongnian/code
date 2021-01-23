    private void buttonStart_Click(object sender, EventArgs e) 
    { 
       using(SqlCeConnection conn = new SqlCeConnection( 
       ("Data Source=" + (Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), "ElectricReading.sdf") + ";Max Database Size=2047"))))
       {
     
           // Connect to the local database 
           conn.Open(); 
           using(SqlCeCommand cmd = conn.CreateCommand())
           {
           SqlCeParameter param = new SqlCeParameter(); 
           param.ParameterName = "@Barcode"; 
           param.DBType = DBType.String; //Intellisense is your friend here but See http://msdn.microsoft.com/en-US/library/system.data.sqlserverce.sqlceparameter.dbtype(v=VS.80).aspx for supported types
           param.Value = "%" + textBarcode.Text.Trim() + "%"; 
     
           // SELECT rows
           cmd.CommandText = "SELECT * FROM Main2 WHERE CONVERT(varchar, Reading) LIKE @Barcode";
           cmd.Parameters.Add(param); 
           
           //cmd.ExecuteNonQuery();  //You don't need this line
     
           DataTable data = new DataTable(); 
     
           using (SqlCeDataReader reader = cmd.ExecuteReader()) 
           { 
               if (reader.Read()) 
               { 
                  data.Load(reader); 
                  this.dataGrid1.DataSource = data; 
               } 
           } 
    
           }
       }
    
    
    } 
