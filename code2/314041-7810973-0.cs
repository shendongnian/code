        public void Initialize()
		{
			Configure = new Configuration();
            Configure.SessionFactoryName(System.Configuration.ConfigurationManager.AppSettings["SessionFactoryName"]);
			Configure.DataBaseIntegration(db =>
			                              {
			                              	db.Dialect<MsSql2008Dialect>();
			                              	db.Driver<SqlClientDriver>();
			                              	db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
			                              	db.IsolationLevel = IsolationLevel.ReadCommitted;
			                              	db.ConnectionStringName = ConnectionStringName;
			                              	db.BatchSize = 20;
			                              	db.Timeout = 10;
			                              	db.HqlToSqlSubstitutions = "true 1, false 0, yes 'Y', no 'N'";
			                              });
            Configure.SessionFactory().GenerateStatistics();
			Map();
		}
