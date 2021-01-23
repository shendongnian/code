       public class portlets
        	{
        		public Portlet()
        		{
        			PrortletId= "";
        			ColumnId= "";
        		}
        		public String PortletId{ get; set; }
        		public String ColumnId { get; set; }
        	}
        
        
        [WebMethod]
        public void SavePortletPositions(Portlet[] portlet)
        {
        // do what you need with the object
        } 
