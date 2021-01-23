    string strSelectSQL = "SELECT [IP Address] as [IPAddress], [MAC Address] as [MACAddress],[Last seen on Channel] as [LastseenonChannel] FROM [NMS_List_Export$]";
    OleDbCommand selectCommand = new OleDbCommand(strSelectSQL, cmd.Connection);
    OleDbParameter paramIP = new OleDbParameter("ip", "");
    OleDbParameter paramMAC = new OleDbParameter("mac", "");
    OleDbParameter paramLastSeen = new OleDbParameter("last_seen", "");
    cmd.CommandText = "INSERT INTO [MS Access;Database=" + Access + "].[NMS_List_Export] VALUES (?, ?, ?)";
    cmd.Parameters.Add(paramIP);
    cmd.Parameters.Add(paramMAC);
    cmd.Parameters.Add(paramLastSeen);
    using (OleDbDataReader reader = selectCommand.ExecuteReader())
    {
        while (reader.Read())
        {
            paramIP.Value = reader[0].ToString();
            paramMAC.Value = reader[1].ToString().Replace(":", " ");
            paramLastSeen.Value = reader[2].ToString();
            cmd.ExecuteNonQuery();
        }
    }
