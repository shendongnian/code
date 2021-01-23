    using System.Collections.Generic;
    
    		public static string sprintf(string Format, ICollection<Object> ParametersAsCollection)
    		{
    			object[] Parameters = null;
    			if (ParametersAsCollection != null)
    			{
    				Parameters = new object[ParametersAsCollection.Count];
    				ParametersAsCollection.CopyTo(Parameters, 0);
    			}
    
    			return sprintf(Format, Parameters);
    		}
