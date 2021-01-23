    string sql = "SELECT * FROM Tigers WHERE Link='" + link + "'";
    MySqlCommand cmd = new MySqlCommand(sql, conn);
    MySqlDataReader rdr = cmd.ExecuteReader();
    if(rdr.HasRows){
        while (rdr.Read())
        {
                //do stuff here
        }
    } else {
        //nothing found
    }
