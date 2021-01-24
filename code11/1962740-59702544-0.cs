    using System;
    using System.Linq;
    // https://stackoverflow.com/questions/59702370/c-sharp-linq-groupby-query-ignoring-where-on-bool
    
    public class Program
    {
    	public static void Main()
    	{
    		var orderEditorViewModel = new 
    		{
    			ParentName = "xyz",
    			EditOrderFitters = new [] 
    			{
    				new EditOrderFitter { Delete = true, OrderFitter = new OrderFitter { Id = 1, Person = "1" } },
    				
    				new EditOrderFitter { Delete = false, OrderFitter = new OrderFitter { Id = 1, Person = "2" } },
    				
    				new EditOrderFitter { Delete = false, OrderFitter = new OrderFitter { Id = 1, Person = "2" } },
    				
    				new EditOrderFitter { Delete = false, OrderFitter = new OrderFitter { Id = 1, Person = "3" } }
    			}
    		};
    		
    		var result = orderEditorViewModel.EditOrderFitters.Where(f => !f.Delete).GroupBy(f => f.OrderFitter.Person);
    		foreach(var item in result)
    			Console.WriteLine("" + " Count: " + item.Count());
    		
    	}
    	
    	public class EditOrderFitter
        {
            
            public bool Delete { get; set; }
            public bool Added { get; set; }
    		public OrderFitter OrderFitter { get; set; }
        }
    	
    	public class OrderFitter 
    	{
    		public int Id { get; set; }
    		public string Person { get; set; }
    	}
    	
    }
 
