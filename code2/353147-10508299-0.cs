    public static class Runner
    {
        public class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }
            public int Timeout { get; set; }
        }
        public static void MigrateToLatest(string connectionString)
        {
            //using (var announcer = new NullAnnouncer())
            using (var announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s)))
            {
                var assembly = Assembly.GetExecutingAssembly();
                var migrationContext = new RunnerContext(announcer)
                {
                    Namespace = "MyApp.Sql.Migrations"
                };
                var options = new MigrationOptions { PreviewOnly=false, Timeout=60 };
                var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2008ProcessorFactory();
                var processor = factory.Create(connectionString, announcer, options);
                var runner = new MigrationRunner(assembly, migrationContext, processor);
                runner.MigrateUp(true);
            }
        }
    }
