    protected void SwitchButtons()
    {
        btnQuery.Visible = false; // Where is btnQuery?
        Button btn1=(Button)FindControlRecursive(GridView1,"btnReturn");
        btn1.true;
    }
    private Control FindControlRecursive(Control rootControl, string controlID)
    {
     if (rootControl.ID == controlID) return rootControl;
        foreach (Control controlToSearch in rootControl.Controls)
        {
        Control controlToReturn =
             FindControlRecursive(controlToSearch, controlID);
        if (controlToReturn != null) return controlToReturn;
        }
       return null;
    }
