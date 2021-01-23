        if (ddlState.SelectedValue == "International (No U.S. State)" && ddlCountry.SelectedValue == "United States")
        {
            CustomValidator1.IsValid = true;
        }
        else
        {
            CustomValidator1.IsValid = false; 
        }
