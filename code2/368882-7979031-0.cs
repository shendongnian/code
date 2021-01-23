	public class NHContext
	{
		protected static Configuration NHConfiguration;
		protected static ISessionFactory SessionFactory;
		public static void DropDatabase()
		{
			new SchemaExport(NHConfiguration).Drop(false, true);
		}
		public static void CreateDatabase()
		{
			new SchemaExport(NHConfiguration).Create(false, true);
		}
		protected static Configuration configureNHibernate()
		{
			var configure = new Configuration();
			configure.SessionFactoryName("BuildIt");
			configure.DataBaseIntegration(db =>
			{
				db.Dialect<MsSql2008Dialect>();
				db.Driver<Sql2008ClientDriver>();//db.Driver<SqlClientDriver>();
				db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
				db.IsolationLevel = IsolationLevel.ReadCommitted;
				db.ConnectionString = @"Data Source=.\SQLEXPRESS;Persist Security Info=True;Integrated Security=SSPI;Initial Catalog=NHibernate32Test;User Instance=False";
				db.Timeout = 10;
				// For testing
				db.LogFormattedSql = true;
				db.LogSqlInConsole = true;
				db.AutoCommentSql = true;
			});
			return configure;
		}
		public static void Setup()
		{
			NHConfiguration = configureNHibernate();
			HbmMapping mapping = getMappings();
			NHConfiguration.AddDeserializedMapping(mapping, "NHibernate32Test");
			SchemaMetadataUpdater.QuoteTableAndColumns(NHConfiguration);
			SessionFactory = NHConfiguration.BuildSessionFactory();
		}
    }
