    interface IFooGet
    {
    	int Id { get; }
    }
    
    interface IFooSet
    {
    	int Id { set; }
    }
    
    public class FooGet : IFooGet
    {
    	public int Id { get; }
    }
    
    public class FooGetSet : IFooGet, IFooSet
    {
    	public int Id { get; set; }
    }
