    using System;
    namespace GridViewDemo
    {
    	public class Entity
    	{
    		public int Id { get; set; }
    		public string Name { get; set; }
    		public string Status 
    		{ 
    			get
    			{
    				if (Id % 42 == 0) { return "Good"; };
    				if (Id % 111 == 0) { return "Bad"; };
    				return "Normal";	
    			} 
    		}
    	}
    }
