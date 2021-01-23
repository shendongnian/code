     //Add the javascript so we know where we want the enter key press to go
    if (!IsPostBack)
    {
       txtboxFirstName.Attributes.Add("onKeyPress", 
                       "doClick('" + btnSearch.ClientID + "',event)");
       txtboxLastName.Attributes.Add("onKeyPress", 
                      "doClick('" + btnSearch.ClientID + "',event)");
    }
