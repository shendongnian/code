    public void AddData(string Column, string value)
        {
            try
            {
                int i = -1;
                char[] delimiterChars = { ',' };
    
    
                queryCutting = @"INSERT INTO [" + strFileNamenopath + "] ( " + Column + " ) VALUES ( " + value + " )";
    
                OleDbCommand cmd = new OleDbCommand(queryCutting, conn);
    
               
                MessageBox.Show(queryCutting);
                cmd.ExecuteNonQuery();
    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);        
            }
    
    
        }
