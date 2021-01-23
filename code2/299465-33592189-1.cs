    using MySql.Data.MySqlClient;
    using System.Windows;
       class Connexion
    {
        public MySql.Data.MySqlClient.MySqlConnection connexion;
        private string server;
        private string database;
        private string uid;
        private string password; 
    
        public Connexion()
        {
            server = "localhost";
            database = "GestionCommeriale";
            uid = "root";
            password = "";
            String connexionString;
            connexionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" +
            "UID" + uid + ";" + "PASSSWORD =" + password + ";";
            connexion = new MySqlConnection(connexionString);
        }
        public bool OpenConnexion()
   {
       try
       {
           connexion.Open();
           return true;
       }
       catch (MySqlException ex)
       {
           switch (ex.Number)
           {
               case 0:
                   MessageBox.Show("Cannot connect to server.  Contact administrator");
                   break;
               case 1045:
                   MessageBox.Show("Invalid username/password, please try again");
                   break;
            }
           return false;
       }
