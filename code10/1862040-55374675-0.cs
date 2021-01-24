    DataTable dt = new DataTable();
    MySqlCommand cmd = new MySqlCommand(cmdText, conn);
    dt.Load(cmd.ExecuteReader());
    if(dt.Rows.Count != 15){
    	//error code
    }else{
    	foreach(DataRow row in dt.Rows){
    		Console.WriteLine(row["Song_title"].ToString());
    	}
    }
