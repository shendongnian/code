    lblDescription.Text = response.SelectedPolicy.Description;
    
    if (SelectedPolicy is MotorPolicy)
        lblReg.Text = ((MotorPolicy)response.SelectedPolicy).Reg;
    
    else if (SelectedPolicy is HouseholdPolicy)
        lblContents.Text = ((HouseholdPolicy)response.SelectedPolicy).Contents;
