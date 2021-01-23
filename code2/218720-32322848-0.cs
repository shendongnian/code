    protected String GetControls(Control control)
    {
        //Get text from form elements
        String text = "";
        foreach (Control ctrl in control.Controls)
        {
            if (ctrl.ClientID.Contains("TextBox"))
            {
                TextBox tb = (TextBox)ctrl;
                text += tb.ID.Replace("TextBox", "") + ": " + tb.Text + "<br />";
            }
            if (ctrl.ClientID.Contains("RadioButtonList"))
            {
                RadioButtonList rbl = (RadioButtonList)ctrl;
                text += rbl.ID.Replace("RadioButtonList", "") + ": " + rbl.SelectedItem.Text + "<br />";
            }
            if (ctrl.ClientID.Contains("DropDownList"))
            {
                DropDownList ddl = (DropDownList)ctrl;
                text += ddl.ID.Replace("DropDownList", "") + ": " + ddl.SelectedItem.Text + "<br />";
            }
    
            if (ctrl.ClientID.Contains("CheckBox"))
            {
                CheckBox cb1 = (CheckBox)ctrl;
                text += cb1.ID.Replace("CheckBox", "") + ": " + cb1.Text + "<br />";
            }
    
            if (ctrl.HasControls())
                text += GetControls(ctrl);
        }
    
        return text;
    }
