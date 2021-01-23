    string comportnumber = "";
    using (SqlCeConnection conn = new SqlCeConnection("Data Source = \\Program Files\\myprogram\\db.sdf; Password ='mypassword'"))
    using (SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM [COMPORT]", conn))
    {
        conn.Open();
        using (SqlCeDataReader rdr = cmd.ExecuteReader())
        {    
            while (rdr.Read())
            {
                comportnumber = rdr.GetString(0);
            }
        }
    }
    serialPort1.PortName = comportnumber;
    serialPort1.Close();
    if (!serialPort1.IsOpen)
        serialPort1.Open();
