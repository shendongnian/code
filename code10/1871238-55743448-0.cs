    public void AddData(string Column, string value)
    {
        try
        {
            char[] delimiterChars = { ','};
    
            // Query text is incomplete, we complete it inside the loop
            queryCutting = @"INSERT INTO [" + strFileNamenopath  + @"] 
                             ( " + Column +  " ) VALUES ( ";
    
            OleDbCommand cmd = new OleDbCommand(queryCutting, conn);
            string[] _valseperated = value.Split(delimiterChars);
            string[] _columnsbase = Column.Split(delimiterChars);
    
    
            foreach (string str in _columnsbase )
            {              
                // The second parameter in AddWithValue is the Value not the type.
                cmd.Parameters.AddWithValue(str, _valseperated[i]);
                queryCutting += "?,";
            }
            queryCutting = queryCutting.Substring(queryCutting.Length-1) + ")";
            cmd.ExecuteNonQuery();
    
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);        
        }
    }
