 sessionFactory = new NHibernate.Cfg.Configuration().Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NHibernate\\Oracle.cfg.xml")).BuildSessionFactory();
            </pre>
i entered these lines:
OracleConnection conn = new OracleConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            conn.Open();
conn.Close();
