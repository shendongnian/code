    using (var gc = new Whatever())
    {
        gc.connect();
        List<Conseiller> conseillers = gc.getAllConseillers();
    }
    --
    public void connect()
    {
        string connStr = "SERVER=localhost;UID=root;DATABASE=Projet;Password=root";
        oConn = new MySqlConnection(connStr);
        try
        {
            oConn.Open();
            Console.WriteLine("Successfully connected to the data base");
        }
        catch (OdbcException ex)
        {
            /* Traitement de l'erreur */
            Console.WriteLine(ex.Message);
            oConn.Dispose();
            oConn = null;
            // optional: throw;
        }
    }
    -- 
    public List<Conseiller> getAllConseillers()
    {
        using (MySqlCommand oComm = oConn.CreateCommand())
        {
            Console.WriteLine("SELECT * FROM conseillers");
            oComm.CommandText = "SELECT * FROM conseillers";
            using (MySqlDataReader oReader = oComm.ExecuteReader()) // No error here
            {
                // process the result in oReader here
                return ...;
            }
            ...
        }
        ...
    }
