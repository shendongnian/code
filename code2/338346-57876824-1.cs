    public void YourUniqueId_Click(Office.IRibbonControl Control)
    {
        //Since the initial value is false and presumably the user just clicked for 
        //the first (or N-th) time you'll want to set the value to true
        if(!_buttonClicked)
        {
            _buttonClicked = true;
        }
        //Or if clicking for a second (or N-th + 1) time, set the value to false
        else
        {
            _buttonClicked = false;
        }
        //Now use the invalidate method from the ribbon variable (from the load method) 
        //to reset the specific control id (in this case "YourUniqueId") from the xml. 
        //Invalidating the control will call the method "GetYourLabelText"
        ribbon.InvalidateControl(Control.Id);      
    }
    
    public string GetYourLabelText(Office.IRibbonUI Control)
    {
        if(_buttonClicked)
        {
            return "Button is On";
        }
        else
        {
            return "Button is Off";
        }
    }
