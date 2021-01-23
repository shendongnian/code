    rlistAvailable_Transferred(object sender, Telerik.Web.UI.RadListBoxTransferredEventArgs e)
    {
    		if (e.DestinationListBox.ID == "rlistAttached") 
    		{
    			foreach (Telerik.Web.UI.RadListBoxItem li in e.Items) 
    		        {
    			//do insert query using li.Value
    		        }
    		} 
    		else 
    		{
    			foreach (Telerik.Web.UI.RadListBoxItem li in e.Items) 
                        {
    			//do delete query using li.Value
    		        }
    	     }
    }
