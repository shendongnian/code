    public void AddData(string Column, string value)
    {
        try
        {
            char[] delimiterChars = { ','};
    
            // Query text is incomplete, we complete it inside the loop
            queryCutting = @"INSERT INTO [" + strFileNamenopath  + @"] 
                             ( " + Column +  " ) VALUES ( ";
    
            // The query and the connection will be set after the loop
            OleDbCommand cmd = new OleDbCommand();
            string[] _valseperated = value.Split(delimiterChars);
            string[] _columnsbase = Column.Split(delimiterChars);
    
            foreach (string str in _columnsbase )
            {              
                // The second parameter in AddWithValue is the Value not the type.
                cmd.Parameters.AddWithValue(str, _valseperated[i]);
                // Add a placeholder for each parameter
                queryCutting += "?,";
            }
            // Remove the ending colon an close the paren on the query text
            queryCutting = queryCutting.Substring(queryCutting.Length-1) + ")";
            cmd.CommandText = queryCutting;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
    
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);        
        }
    }
