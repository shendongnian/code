    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace StackOverflow.MyExtensions
    {
    	public static class ObjectExtentions
    	{
    
    		public static Boolean PropertyExists(this object Object, string PropertyName)
    		{
    
    			var ObjType = Object.GetType();
    
    			var TypeProperties = ObjType.GetProperties();
    
    			Boolean PropertyExists = TypeProperties
    					.Where(x => x.Name == PropertyName)
    					.Any();
    
    			return PropertyExists;
    
    		}
    
    	}
    }
