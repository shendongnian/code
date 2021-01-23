    foreach (var each in pnlProcessCon.Controls)
    {
        String[] temp = new String[3];
        foreach (var control in each.Controls)
        {
            // check if control is the Process control that you want
            temp = ((TextBox)control).Text;                    
        }
    }
