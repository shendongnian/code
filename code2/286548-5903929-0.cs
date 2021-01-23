    private Boolean blnSystem = false;
    
    private void SystemChanges()
    {
        try
        {
            blnSystem = true;
    
            //Code which changes listBox1 Item Checked values
        }
        catch
        {
            //Error handler
        }
        finally
        {
            blnSystem = false;
        }
    }
    
    private void listBox1_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
        if (!blnSystem) //Should check if item was clicked.
        {
            //Do some stuff
        }
        else //If the event was fired because I changed the Checked property from the code
        {
            //Do some other stuff
        }
    }
