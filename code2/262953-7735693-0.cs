    //This is fairly expensive so cache the types
    static DummyRepository()
    {
    	foreach( var type in typeof( SomeTypeInAssemblyWithModelObjects ).Assembly.GetTypes() )
    	{
    		if( !type.IsClass | type.IsAbstract || !type.IsPublic || type.IsGenericTypeDefinition )
    		{
    			continue;
    		}
    
    		g_types.Add( type );
    	}
    }
    
    public DummyRepository()
    {
    	MockRepository = new Mock<ISomeRepository>();
    
    	var setupLoadBy = GetType().GetMethod( "SetupLoadBy", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod );
    
    	foreach( var type in g_types )
    	{
    		var loadMethod = setupLoadBy.MakeGenericMethod( type );
    		loadMethod.Invoke( this, null );
    	}
    }
    
    private void SetupLoadBy<T>()
    {
    	MockRepository.Setup( u => u.Load<T>( It.IsAny<long>() ) ).Returns<long>( LoadById<T> );
    }
    
    public T LoadById<T>( long id )
    {
    }
