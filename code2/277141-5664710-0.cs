     if (this.mDBConnection.State != System.Data.ConnectionState.Open)
                {
                   try
                   {
                      this.mDBConnection.ConnectionString = this.mDBConnectionString;
                      this.mDBConnection.Open();
                   }
                   catch (System.Exception ex)
                   {
                      ret = false;         
                      throw ex;
                   }
                } 
