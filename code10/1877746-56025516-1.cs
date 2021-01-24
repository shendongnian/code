    private static  IEdmModel GetEdmModel()
    {
        var modelBuilder = new ODataConventionModelBuilder();
    
        // ENTITY SETS: Normal
        modelBuilder.EntitySet<tblDbcCommunications>("Communication");
        modelBuilder.EntitySet<tblDbcItems>("Item");
        modelBuilder.EntitySet<Meter>("Meter");
        modelBuilder.EntitySet<Product>("Product");
        modelBuilder.EntitySet<WarehouseMeter>("WarehouseMeter");
        modelBuilder.EntitySet<Shakeout>("Shakeout");
        modelBuilder.EntitySet<tblDbcCircuitOwner>("tblDbcCircuitOwner");
    
        // ENTITY SETS: Complex
        ConfigureComplexEntitySet(modelBuilder, modelBuilder.EntitySet<ShakeoutDocument>("ShakeoutDocument"));
    
        // KEY BINDINGS
        modelBuilder.EntityType<WarehouseMeter>().HasKey(x => x.METER_ID);
    
        // UNBOUND FUNCTIONS
        //  - Action    = Post
        //  - Function  = Get
    
        // WarehouseMeter
        var findPulseMeter = modelBuilder.Function("FindWarehouseMeter").ReturnsCollectionFromEntitySet<WarehouseMeter>("WarehouseMeter");
        findPulseMeter.Parameter<string>("search");
    
        // ShakeoutDocument
        var getShakeoutDocument = modelBuilder.Function("GetShakeoutDocument").ReturnsFromEntitySet<ShakeoutDocument>("ShakeoutDocument");
        getShakeoutDocument.Parameter<int>("id");
    
        // Product
        var listProduct = modelBuilder.Function("ListProducts").ReturnsCollectionFromEntitySet<Product>("Product");
    
        return modelBuilder.GetEdmModel();
    }
    
    private static EntitySetConfiguration<ShakeoutDocument> ConfigureComplexEntitySet(ODataConventionModelBuilder modelBuilder, EntitySetConfiguration<ShakeoutDocument> configuration)
    {
        // Collection Properties
        configuration.EntityType.CollectionProperty(x => x.Seals);
        configuration.EntityType.CollectionProperty(x => x.Details);
        // Complex Properties
        configuration.EntityType.ComplexProperty(x => x.ObjectState);
    
        // Object State
        var newObjectState = modelBuilder.ComplexType<New>();
        newObjectState.DerivesFrom<IObjectState>();
    
        var submittedObjectState = modelBuilder.ComplexType<Submitted>();
        submittedObjectState.DerivesFrom<IObjectState>();
    
        // Object State Event
        var isNewObjectStateEvent = modelBuilder.ComplexType<IsNew>();
        isNewObjectStateEvent.DerivesFrom<IObjectStateEvent>();
    
        var isSubmittedObjectStateEvent = modelBuilder.ComplexType<IsSubmitted>();
        isSubmittedObjectStateEvent.DerivesFrom<IObjectStateEvent>();
    
        return configuration;
    }
