        public class SigepBootstrapper : MefBootstrapper
        {
            protected override void ConfigureAggregateCatalog()
            {
                this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(SigepBootstrapper).Assembly));
                this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(AutoPopulateExportedViewsBehavior).Assembly));
                this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(StatusBarView).Assembly));
                this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Traversals).Assembly));
                this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(EngineManager).Assembly));
            }
    ...
