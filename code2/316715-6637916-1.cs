    SqlCommand sqlComm = new SqlCommand("SELECT * FROM Info where name='+server+'", sqlConn);
        SqlDataReader r = sqlComm.ExecuteReader();
        while ( r.Read() ) {
            string name = (string)r["Name"];
            Debug.WriteLine(username + "(" + userID + ")");
        }
        r.Close();
