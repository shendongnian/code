    string taglineActive;
    OLRegistryAddin buttonSet = new OLRegistryAddin();  // variable for reading the value of the registry key
    UpdateBody msgBody = new UpdateBody();  // method for adding/removing tagline from the message
    private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
    {
        taglineActive = buttonSet.RegCurrentValue();  // retrieve the current registry value
        if (taglineActive == "0")
        {
            // tagline is off for all messages
            ActiveAllMessages.Checked = false; // uncheck "All Messages" button
            ActiveAllMessages.Label = "Inactive - All Messages";  // change the label
            ActiveThisMessage.Visible = false;  // hide the "This Message" button
            ActiveThisMessage.Enabled = false;  // deactivate the "This Message" button
        }
        else if (taglineActive == "1")
        {
            // tagline is on for all messages
            ActiveAllMessages.Checked = true;   // check "All Messages" button
            ActiveAllMessages.Label = "Active - All Messages";  // change the label
            ActiveThisMessage.Visible = true;   // show the "This Message" button
            ActiveThisMessage.Enabled = true;   // activate the "This Message" button
        }
