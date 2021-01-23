    public class mefStart
    {
        [Import]
        private IClass3 my3;
        public CompositionContainer Container { get; private set; }
        public void Start()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(typeof(Program).Assembly);
            DirectoryCatalog directoryCatalog = new DirectoryCatalog(".", "Library*.dll");
            catalog.Catalogs.Add(directoryCatalog);
            catalog.Catalogs.Add(assemblyCatalog);
            this.Container = new CompositionContainer(catalog);
            CompositionBatch batch = new CompositionBatch();
            batch.AddExportedValue(this.Container);
            this.Container.Compose(batch);
            this.Container.ComposeParts(this);
            //from here you can use Class3 with all imports
        }
    }
    [Export(typeof(IClass3)]
    public class Class3:IClass3
    {
        [Import]
        public IClass1 Class1 { get; set; }
        [Import]
        public IClass2 Class2 { get; set; }
        public void Trigger()
        {
            Class1.Trigger();
            Class2.Trigger();
        }
    }
