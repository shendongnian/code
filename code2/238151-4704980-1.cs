     protected override void OnInit(EventArgs e)
    {
        try
        {
            //Change your condition here
            if (Session["boolSignOn"].ToString() == "true".ToString() && Session["panelOpen"] != null)               
            {              
                lblPanelOpen.Text = Session["panelOpen"].ToString();
            }
            else
            {
                //Dont set text to panelOpen here
                lblPanelOpen.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            Logger.Error("Error processing request:" + ex.Message);
        }
    }
    protected override void OnLoad(EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(Session["panelOpen"].ToString()))
            {
                // No need to set it here it will be set in next load in OnInit call 
                //lblPanelOpen.Text = string.Empty;
                Session.Remove("panelOpen");
            }
       }
       catch (Exception ex)
       {
           Logger.Error("Unable to remove the session variable:" + ex.Message);
       }
