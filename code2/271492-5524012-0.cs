    List<Conseiller> conseillers = gc.getAllConseillers();
    public void getAll() {
      string connStr = "SERVER=localhost;UID=root;DATABASE=Projet;Password=root";
      using (oConn = new MySqlConnection(connStr))
      using (MySqlCommand oComm = oConn.CreateCommand())
      {
        oConn.Open();
        oComm.CommandText = "SELECT * FROM conseillers";
        MySqlDataReader oReader = oComm.ExecuteReader(); // no Error here
        // user reader here
        } catch (OdbcException caugth) {
            /* Traitement de l'erreur */
            Console.WriteLine(caugth.Message);
        }
     }
