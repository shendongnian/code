    HtmlControl GetParentIFrame()
    {
    	HtmlControl parentIFrame = null;
    	if (!Resource.ControlType.ToLower().Equals("getactivityid"))
    	{
        	parentIFrame = new HtmlControl(Resource.ProjectBrowserWindow);
        	if (Resource.ControlType.ToLower().Equals("hyperlink"))
        	   parentIFrame.SearchProperties.Add(HtmlControl.PropertyNames.Id, "bike-insurance");
        	else
        	   parentIFrame.SearchProperties.Add(HtmlControl.PropertyNames.Id, "section_wise_container");
       		return parentIFrame;
       }
       return parentIFrame;
    }
    
    HtmlControl GetInsuranceData(HtmlControl parentIFrame)
    {
    	HtmlControl insurancedata = null;
    	if (Resource.ControlGenricName.ToLower().Contains("finalsubmitbutton"))
    	{
    	    HtmlControl insurancedata = new HtmlControl(parentIFrame);                    
    	    insurancedata.SearchProperties.Add(HtmlControl.PropertyNames.Id, 
    	    "ResultButton");
    	}
    	return insurancedata;
    }
