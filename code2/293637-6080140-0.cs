    // Do you really need to check names instead of just references?
    // You could probably just use
    // if (myControl != checkBox3 && myControl != panel7)
    if (myControl.Name != checkBox3.Name && myControl.Name != panel7.Name)
    {
        // No need for your if block here
        myControl.Enabled = checkBox3.Checked;
    }
