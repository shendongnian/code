    public class Program
    {
        [ImportMany(AllowRecomposition=true)]
        public IEnumerable<Settings> Settings { get; set; }
        public void RunTest()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Settings).Assembly));
            CompositionContainer container = new CompositionContainer(catalog);
            // Settings should have 0 values.
            container.ComposeParts(this);
            Contract.Assert(this.Settings.Count() == 0);
            CompositionBatch batch = new CompositionBatch();
            // Store the settingsPart for later removal...
            ComposablePart settingsPart = 
                batch.AddExportedValue(new Settings { ConnectionString = "Value1" });
            container.Compose(batch);
            // Settings should have "Value1"
            UsesSettings result = container.GetExportedValue<UsesSettings>();
            Contract.Assert(result.TheSettings.ConnectionString == "Value1");
            // Settings should have 1 value which is "Value1";
            Contract.Assert(this.Settings.Count() == 1);
            Contract.Assert(this.Settings.First().ConnectionString == "Value1");
            // Remove the old settings and replace it with a new one.
            batch = new CompositionBatch();
            batch.RemovePart(settingsPart);
            batch.AddExportedValue(new Settings { ConnectionString = "Value2" });
            container.Compose(batch);
            // result.Settings should have "Value2" now.
            Contract.Assert(result.TheSettings.ConnectionString == "Value2");
            // Settings should have 1 value which is "Value2"
            Contract.Assert(this.Settings.Count() == 1);
            Contract.Assert(this.Settings.First().ConnectionString == "Value2");
        }
    }
    public class Settings
    {
        public string ConnectionString = "default value";
    }
    [Export(typeof(UsesSettings))]
    public class UsesSettings
    {
        [Import(typeof(Settings), AllowRecomposition = true)]
        public Settings TheSettings { get; set; }
    }
