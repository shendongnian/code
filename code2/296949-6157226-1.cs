    TextBox txtProcess = new TextBox();
    txtProcess.Name = "Process";
    //configure other textboxes, add to panels, etc.
    foreach (Panel each in pnlProcessCon.Controls)
    {
        String[] temp = new String[3];
        foreach (Control control in each.Controls)
        {
            if(control.Name == "Process")
            {
                temp[0] = ((TextBox)control).Text;
            }
        }
    }
