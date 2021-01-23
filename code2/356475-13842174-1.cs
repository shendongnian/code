    private void BK()
    {
    string strconn = @"Data Source=.\SQLEXPRESS; AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True;User Instance=True"; 
    SqlConnection conn = new SqlConnection();
    conn.ConnectionString = strconn;
    try {
    // First get the db name
         conn.Open();
            string dbname;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            dbname = cmd.Connection.Database.ToString();       
        //Query per backup
       string queryBK = "BACKUP DATABASE " + dbname + " TO DISK ='C:\\Program Files\\Microsoft SQLServer\\MSSQL10.SQLEXPRESS\\MSSQL\\Backup\\db.bak' WITH INIT, SKIP, CHECKSUM";
       SqlCommand cmdBK = new SqlCommand(queryBK, conn);
       conn.Open();            
       cmdBK.ExecuteNonQuery();
       MessageBox.Show("backup effettuato");
    }
    catch (Exception ex) {
       MessageBox.Show(ex.Message, "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    finally {
       conn.Close();
    }
    }
