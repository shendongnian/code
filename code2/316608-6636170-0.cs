    OdbcCommand cmd = new OdbcCommand(
        "Select nickname, city, country, zipcode from awm_profiles WHERE email LIKE '%softmail.me%' LIMIT 0 , 30",
         MyConnection);
    
    OdbcDataReader dr = cmd.ExecuteReader();
    if (dr.HasRows == false)
    {
        //throw new Exception();
    }
    StringBuilder builder = new StringBuilder();
    while (dr.Read())
    {
        string a = dr[0].ToString();
        string b = dr[1].ToString();
        string c = dr[2].ToString();
        string d = dr[3].ToString();
    	builder.AppendLine(a);
    	builder.AppendLine(b);
    	builder.AppendLine(c);
    	builder.AppendLine(d);
     }
     
     Response.Write(bulder.ToString());
