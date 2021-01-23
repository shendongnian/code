    using (OracleCommand cmd = new OracleCommand("SP1", OraCon) { CommandType = System.Data.CommandType.StoredProcedure })
    {
        var parm_nic = cmd.Parameters.Add("parm_nic", OracleDbType.NVarchar2);
        parm_nic.Value = msgBody;
    
        var pram_Name = cmd.Parameters.Add("pram_Name", OracleDbType.NVarchar2, 150, ParameterDirection.Output);
        var pram_PAdress = cmd.Parameters.Add("pram_PAdress", OracleDbType.NVarchar2, 150, ParameterDirection.Output);
        var output = cmd.Parameters.Add("pram_status", OracleDbType.RefCursor, ParameterDirection.Output);
        OraCon.Open();
    
        OracleDataAdapter ad = new OracleDataAdapter(cmd);
        OracleCommandBuilder cb = new OracleCommandBuilder(ad);
    
        DataTable dt = new DataTable();
        ad.Fill(dt);
    
        var address = pram_PAdress.Value;
        var name = pram_Name.Value;
    }
