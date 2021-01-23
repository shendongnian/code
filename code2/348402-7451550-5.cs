    public bool Control_Visible(Office.IRibbonControl control)
    {
        // In order to maintain a reference to the groups, I store the controls into a List<Office.IRibbonControl>.
        if(!this.groupControls.Contains(control))
        {
            this.groupControls.Add(control);
        }         
        // logic here to determine if it should return true or false to be visible...
        return true;
    }
