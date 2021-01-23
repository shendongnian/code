    class Program
    {
    	[ImportMany]
    	private List<Lazy<IGatewayResponseReader, IGatewayResponseReaderMetadata>> _readers;
    
    	static void Main( string[] args )
    	{
    		CompositionContainer container = new CompositionContainer( new AssemblyCatalog( Assembly.GetExecutingAssembly() ) );
    
    		Program program = new Program();
    		container.SatisfyImportsOnce( program );
    
    
    		var reader = program._readers.FirstOrDefault( r => r.Metadata.Key == "value1" );
    		if ( reader != null )
    			reader.Value.Read( ... );
    	}
    }
