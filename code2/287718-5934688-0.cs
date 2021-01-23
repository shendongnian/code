    static public SqlConnection conn;     
    static public SqlConnection GetConnected() {         
        try         
        {             
            String strConnectionString = ConfigurationManager.ConnectionStrings["xxxxx"].ConnectionString;             
            conn = new SqlConnection(strConnectionString);
        } 
    }
    static public void CloseConnection() {           
        // Libération de la connexion si elle existe           
        if (IsConnected) conn.Close();       
    }   
