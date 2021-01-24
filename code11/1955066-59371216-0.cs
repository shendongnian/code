    public class ConsultasBD : IDisposable
    {
        private SqlConnection conexionBD{get;set;};
        Configuration config = null; 
        string valEmp = String.Empty;
        private const string Empresa = "3";
        public ConsultasBD()
        {
            config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath); 
            valEmp  = config.AppSettings.Settings["EMPRESA"];
            conexionBD = new SqlConnection(config.AppSettings["ggConnectionString"]);
        }
    }
