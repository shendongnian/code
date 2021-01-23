    SqlDataAdapter sqlAdap = new SqlDataAdapter(query, connection);
    DataTable dt = new DataTable();
    sqlAdap.Fill(dt);
    
    string filePath = Server.MapPath("~/filename.xml");
    dt.WriteXml(filePath);
