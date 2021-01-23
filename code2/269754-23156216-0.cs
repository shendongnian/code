    using (SqlCeConnection con = new SqlCeConnection(strConn))
    {
        SqlCeParameter par;
        con.Open();
        SqlCeCommand cmd = con.CreateCommand();
        cmd.CommandText = "insert into CustTable(ID, Name) values (@Val1, @val2)";
        // Create the parameters
        par = new SqlCeParameter("@Val1", SqlDbType.Int);
        cmd.Parameters.Add(par); 
        par = new SqlCeParameter("@Val2", SqlDbType.NChar, 50);
        cmd.Parameters.Add(par);
        // Set the values        
        cmd.Parameters["@Val1"].Value = customer.ID;
        cmd.Parameters["@Val2"].Value = customer.Name;
        cmd.ExecuteNonQuery();
        // Dispose
        cmd.Dispose();
    }
