    protected void setColor(Control Ctl)
    {
        foreach (Control cntrl in Ctl.Controls)
        {
             if (cntrl.GetType().Name == "TextBox")
             {
                  //Do Code
             }
             setColor(Control cntrl);
        }
    }
