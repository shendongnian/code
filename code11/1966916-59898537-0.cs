    DataTable dt = new DataTable();
    dt.Columns.Add(new DataColumn("Kantoor", typeof(string)));
    dt.Columns.Add(new DataColumn("Taal", typeof(string)));
    dt.Columns.Add(new DataColumn("Spreken", typeof(string)));
    dt.Columns.Add(new DataColumn("Lezen", typeof(string)));
    dt.Columns.Add(new DataColumn("Schrijven", typeof(string)));
    dt.Columns.Add(new DataColumn("Talen_op_werknemerID", typeof(string)));
    for(int x = 0; x < languageMatches.Length; x++)
    {
        string lang = languageMatches[x];
        string known = knowhowMatches[x];
        dt.Rows.Add(new string[] { "1", lang, lang, lang, known, werknemerId });
    }
    using(SqlConnection Conn = new SqlConnection(connstring))
    {
        Conn.Open();
        using (SqlBulkCopy bc = new SqlBulkCopy(Conn))
        {   
            bc.DestinationTableName = "Talen";
            bc.WriteToServer(dt);
        );
    }
