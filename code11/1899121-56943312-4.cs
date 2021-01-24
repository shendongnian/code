    if (!Resource.ControlType.ToLower().Equals("getactivityid"))
    {
        parentIFrame = new HtmlControl(Resource.ProjectBrowserWindow)
                            .AddIdSearch(Resource.ControlType.ToLower().Equals("hyperlink") ? "bike-insurance" : "section_wise_container");
    }
    if (Resource.ControlGenericName.ToLower().Contains("finalsubmitbutton"))
    {
        insurancedata = new HtmlControl(parentIFrame)
                            .AddIdSearch("ResultButton");
    }
