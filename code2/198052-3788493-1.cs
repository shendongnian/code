    // Load the Master Page
    var site1Master = LoadControl("Site1.Master");
    // Find the list of ContentPlaceHolder controls
    IList<Control> controls = WebHelper.FindControlType<ContentPlaceHolder>(site1Master);
    // Do something with each control that was found
    foreach (Control control in controls)
    {
      Response.Write(control.ClientID);
      Response.Write("<br />");
    }
