      // Load the Master Page
      var site1Master = LoadControl("Site1.Master");
      // Find the list of ContentPlaceHolder controls
      var controls = WebHelper.FindControlsByType<ContentPlaceHolder>(site1Master);
      // Do something with each control that was found
      foreach (var control in controls)
      {
        Response.Write(control.ClientID);
        Response.Write("<br />");
      }
