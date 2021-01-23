    class MyFactory
    {
        [ImportMany("MyFactoryExport")]
        public List<Object> Registrations { get; set; }
        public MyFactory()
        {
            AssemblyCatalog catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
    [Export("MyFactoryExport")]
    class MyClass1
    { }
    [Export("MyFactoryExport")]
    class MyClass2
    { }
    [Export("MyFactoryExport")]
    class MyClass3
    { }
