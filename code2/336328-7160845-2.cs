    NpgsqlConnection conn = new NpgsqlConnection(connStr);
    conn.Open();
    
    NpgsqlCommand insertCmd =
    	new NpgsqlCommand("INSERT INTO binaryData (data) VALUES(:dataParam)", conn);
    NpgsqlParameter param = new NpgsqlParameter("dataParam", NpgsqlDbType.Bytea);
    
    byte[] inputBytes = BitConverter.GetBytes((int)0);
    Console.Write("Input:");
    foreach (byte b in inputBytes)
    	Console.Write(" {0}", b);
    Console.WriteLine();
    
    param.Value = inputBytes;
    insertCmd.Parameters.Add(param);
    insertCmd.ExecuteNonQuery();
    
    NpgsqlCommand selectCmd = new NpgsqlCommand("SELECT data FROM binaryData", conn);
    NpgsqlDataReader dr = selectCmd.ExecuteReader();
    if(dr.Read())
    {
    	Console.Write("Output:");
    	byte[] result = (byte[])dr[0];
    	foreach(byte b in result)
    		Console.Write(" {0}", b);
    	Console.WriteLine();
    }
    
    conn.Close();
