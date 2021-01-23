    public void TestMethod1()
    {
    	var assembly = System.Reflection.Assembly.GetExecutingAssembly();
    	Type t = assembly.GetType("FileHelpers.Tests.CustomersFixedWithNumericId");
    	FileHelperEngine engine = new FileHelperEngine(t);
    	
    	string path = @"pathtofile\BadCustomersFixedNumericId.txt";
    
    	engine.AfterReadRecord += new Events.AfterReadHandler<object>(engine_AfterReadRecord);
    	var res = engine.ReadFile(path);
    }
    
    void engine_AfterReadRecord(EngineBase engine, Events.AfterReadEventArgs<object> e)
    {
    	// validation here
    }
