            protected void uxRoleCheckBoxSelector_CheckChanged(object sender, EventArgs e)
        {
            // Cast sender to CheckBox
            CheckBox activeCheckBox = (CheckBox)sender;
            // Retrieve the row where CheckBox is contained (NamingContainer used to retrive parent control
            GridViewRow row = (GridViewRow)activeCheckBox.NamingContainer;
            if (activeCheckBox.Checked == true)
            {
                uxMessageDisplayer.Text = "T - Aproved User";
            }
            else
            {
                uxMessageDisplayer.Text = "F - NOT Aproved User";
            }
        }
