    public string conn;
    
    public void GetInformationFromDatabase()
    {
        conn = "Data Source=server.database.windows.net;Initial 
        Catalog=baza;Persist Security Info=True; Trusted_Connection=False; 
        User ID=" +username+ "; Password=" +userpass;
    }
