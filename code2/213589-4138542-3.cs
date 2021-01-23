    class CustomerDL   
    { 
        OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CIS3341.accdb;");   
        public string GetNames()
        {
            string NamesToReturn = ""; 
            try 
            {
                OleDbDataAdapter myAdapter = new OleDbDataAdapter();     
                if (aConnection.State == ConnectionState.Closed)     
                {     
                    aConnection.Open();     
                }     
                OleDbCommand cmd = aConnection.CreateCommand();     
                OleDbDataReader dbReader = null;     
                cmd.CommandText = "SELECT CustomerName FROM Customer";    
                dbReader = cmd.ExecuteReader();     
                while (dbReader.Read())     
                {     
                    NamesToReturn +=  (string)dbReader["CustomerName"].ToString() + "\r\n";     
                }     
     
                dbReader.Close();
            catch(Exception ex)
            {
            }
            finally
            {
                aConnection.Close(); //makes sure it closes...
            }   
    
                
            return NamesToReturn;
         }     
    }    
  
