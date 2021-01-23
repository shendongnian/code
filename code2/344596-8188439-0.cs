    List<ClassB> allTheBs;
    
    SomeContext ctx = new SomeContext();
    
    LoadOperation<ClassA> loader = ctx.Load( context.GetClassaQuery().Where(...) );
    loader.Completed += (s,e) =>
    	{
    		var entities = (s as LoadOperation<ClassA>).Entities;
    
    		allTheBs = entities.Select ( a => new ClassB()
    				{
    					a.Field1 = b.SomeField,
    					a.Field2 = b.SomeOtherField
    				} );
    	};
