    [SetUp]
    public void SetupContext()
    {
        var schema = new SchemaExport(_configuration);
        schema.Create(true, true);
        InitializeData();    //create your StockItems, StockLocations, and StockTransactions
        CreateInitialData();
    }
