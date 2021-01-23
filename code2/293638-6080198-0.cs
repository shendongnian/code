    private void DisableMessageControls(Control myControl)
    {
        if (myControl.Name == checkBox3.Name || myControl.Name == panel7.Name || myControl.Name == tpMessage.Name)
        {
            
        }
        else
        {
            myControl.Enabled = checkBox3.Checked;
        }
        foreach (Control myChild in myControl.Controls)
            DisableMessageControls(myChild);
    
    }
