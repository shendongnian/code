    class MainObject
    {
    	Collection<IPart> Parts {get;set;}
    }
    
    interface IPart
    {
    	MainObject MainObject {get;set;}
    }
    
    class SomePartImpl : IPart
    {
    	//properties of this IPart implementation
    }
