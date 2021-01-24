    foreach(DataRow row in dt.Rows)
    {
    	string qryName = "select Environment from [CLOUD].cloudsql.caa.aa_AT_S B where A.ServerName = '"+row["ServerName"].ToString()+"'";
    		
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = aadSQLConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = qryName;
            using (SqlDataAdapter daa = new SqlDataAdapter(cmd))
            {
                .....update your datable here
            }
        }
    }
