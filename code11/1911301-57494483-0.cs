    interface ISubdependency { }
    
    interface ISubdependencyA : ISubdependency { }
    
    class SubdependencyA : ISubdependencyA { }
    
    interface IRootA {}
    
    class RootA : IRootA
    { 
    	public RootA(ISubdependency subdependency)
    	{
    			
    	}
    }
    
    interface ISubdependencyB : ISubdependency { }
    
    class SubdependencyB : ISubdependencyB { }
    
    interface IRootB {}
    
    class RootB : IRootB
    {
    	public RootB(ISubdependency subdependency)
    	{
    
    	}
    }
