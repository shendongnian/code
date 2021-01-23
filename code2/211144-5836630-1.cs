    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace HQ.Util.WinFormUtil
    {
    	public class PropertyGridInitialExpandedAttribute : Attribute
    	{
    		public bool InitialExpanded { get; set; }
    
    		public PropertyGridInitialExpandedAttribute(bool initialExpanded)
    		{
    			InitialExpanded = initialExpanded;
    		}
    	}
    }
