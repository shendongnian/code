	if (!Resource.ControlType.ToLower().Equals("getactivityid"))
	{
		var parentIFrame = new HtmlControl(Resource.ProjectBrowserWindow)
		{
		    SearchProperties =
            {
                HtmlControl.PropertyNames.Id, 
                (Resource.ControlType.ToLower().Equals("hyperlink")) ? "bike-insurance" : "section_wise_container" 
            }
		};
	}
