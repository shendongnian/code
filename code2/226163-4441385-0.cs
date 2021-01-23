    [Export]
    public class Worker1
    {
      [Import]
      public IDataProvider DataProvider;
    
      [Import]
      public Worker2 second;
    
      //use data provider to perform logic
      public void DoSomethingWithProvider() {
        }
    }
    
    [Export]
    public class Worker2
    {
      [Import]
      public IDataProvider DataProvider;
    
      //use data provider to perform logic
    }
    
    [Export( typeof( IDataProvider ) )]
    public class GeoDataProvider : IDataProvider
    {
      //implements logic
    }
    
    public class Container
    {
      [Import]
      private Worker1 t1;
    
      public void Init()
      {
        AggregateCatalog cat = new AggregateCatalog();
        cat.Catalogs.Add( new AssemblyCatalog( Assembly.GetExecutingAssembly() ) );
        cat.Catalogs.Add( new DirectoryCatalog( "." ) );
    
        CompositionContainer c = new CompositionContainer( cat );
        c.ComposeParts( this );
      }
    
      public void PerformLogic()
      {
        t1.DoSomethingWithProvider();
      }
    }
