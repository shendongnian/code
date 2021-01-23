    public class TestModel  
    {
    	[Price]
    	public decimal Price1 { get; set; } // ok
    
    	[Price]
    	public double Price2 { get; set; } // error
    }
