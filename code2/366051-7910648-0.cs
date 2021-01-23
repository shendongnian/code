    static void Main(string[] args)
    {
        InitMefContainer();
    
        var test = _Container.GetExportedValue<TestHarness>();
        test.RunTest();
    
        Console.ReadLine();
    }
    
    private static void InitMefContainer()
    {
        var catalog = new AggregateCatalog();
        catalog.Catalogs.Add(new AssemblyCatalog(typeof(EventLogFactory).Assembly));
        catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
        var container = new CompositionContainer(catalog);
        container.ComposeParts();
        _Container = container;
    }
    
    [Export]
    public class TestHarness
    {
      [Import(typeof(IEventLog))]
      public IEventLog EventLog { get; set; }
    
      public void RunTest()
      {
         // did not expect to need to do this, but EventLog is null if I don't
         Program._Container.ComposeParts(this);
    
         this.EventLog.Write(some test event stuff);
      }
    }
