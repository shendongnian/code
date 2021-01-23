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
