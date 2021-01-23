    const string DB_CONN_STR = "Server=127.0.0.1;Uid=foo_dbo;Pwd=pass;Database=foo_db;";
    
    MySqlConnection cn = new MySqlConnection(DB_CONN_STR);
    
    MySqlDataAdapter adr = new MySqlDataAdapter("category_hierarchy", cn);
    
    adr.SelectCommand.CommandType = CommandType.StoredProcedure;
    DataTable dt = new DataTable();
    adr.Fill(dt); //opens and closes the DB connection automatically !!
    
    foreach(DataRow dr in dt.Rows){
        Console.WriteLine(string.Format("{0} {1}", 
            dr.Field<uint>("cat_id").ToString(), dr.Field<string>("cat_name").ToString()));
    }
    cn.Dispose();
  
