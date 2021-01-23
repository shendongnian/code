    // this occurs as part of Initialisation via the designer or you can hook up manually
    myControl.KeyDown += myControl_KeyChange;
    myControl.KeyUp += myControl_KeyChange;
    // ...
    
    private void myControl_KeyChange(object sender, KeyEventArgs e)
    {
        switch( e.KeyCode )
        {
            case Keys.1:
            {
                // handle the 1 key being pressed
                break;
            }        
            case Keys.2:
            {
                // handle the 2 key being pressed
                break;
            }
            // etc
        }
    }
