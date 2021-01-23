    private void Form1_HelpRequested(object sender, HelpEventArgs hlpevent)
    {
        // Existing example code goes here.
    
    	// Use the sender parameter to identify the context of the Help request.
    	// The parameter must be cast to the Control type to get the Tag property.
    	Control senderControl = sender as Control;
    
    	//Recursively search below the sender control for the first control with a Tag defined to use as the help message.
    	Control controlWithTag = senderControl;
    	do
    	{
    		Point clientPoint = controlWithTag.PointToClient(hlpevent.MousePos);
    		controlWithTag = controlWithTag.GetChildAtPoint(clientPoint);
    
    	} while (controlWithTag != null && string.IsNullOrEmpty(controlWithTag.Tag as string));
    
        // Existing example code goes here.    
	}
