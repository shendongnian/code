    protected void CustomValidator1_ServerValidate( object source, 
        ServerValidateEventArgs args )
    {
        if ( ddlState.SelectedValue == "International (No U.S. State)" 
             && ddlCountry.SelectedValue == "United States" )
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
    
    protected void btnContinue_Click( object sender, EventArgs e )
    {
        if ( !Page.IsValid )
            return;
        
        // do whatever the continue button is supposed to do
    }
