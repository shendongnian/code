    public class Database
    {
        private string serverLEGOCUSTOM, serverLEGO;
        private string ConnectionStringLEGOCUSTOM, ConnectionStringLEGO;
        private SqlConnection connectionLEGOCUSTOM, connectionLEGO;
        public Database()
        { 
            serverLEGOCUSTOM = ConfigurationManager.AppSettings["DataServerLEGOCUSTOM"];
            ConnectionStringLEGOCUSTOM = ConfigurationManager.ConnectionStrings[serverLEGOCUSTOM.ToString();
            connectionLEGOCUSTOM = new SqlConnection(ConnectionStringLEGOCUSTOM);
            serverLEGO = ConfigurationManager.AppSettings["DataServerPCI"]
            ConnectionStringLEGO = ConfigurationManager.ConnectionStrings["serverLEGO"].ToString();
            connectionLEGO = new SqlConnection(ConnectionStringLEGO);
        }
