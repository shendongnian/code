    foreach (Control RBL in pnlMain.Controls)
    {
        if (RBL is RadioButtonList)
        {
            foreach (ListItem LI in (RBL as RadioButtonList).Items)
            {
                if (LI.Text.EndsWith("5") && LI.Selected)
                {
                    // Do something with the radiobutton
                }
            }
        }
    }
