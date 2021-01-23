    foreach (Control RBL in pnlMain.Controls)
    {
        if (RBL is RadioButtonList)
        {
            foreach (Control Ctrl in (RBL as RadioButtonList).Controls)
            {
                if (Ctrl.ID.EndsWith("5") && Ctrl is RadioButton && (Ctrl as RadioButton).Checked)
                {
                    RadioButton RBCtrl = Ctrl as RadioButton;
                    // Do something with the radiobutton
                }
            }
        }
    }
