       UserControl[] ucs = new UserControl[3]{
             usercontrol1,
             usercontrol2,
             usercontrol3
       };
       foreach (UserControl uc in ucs){
            foreach (Control c in uc.FindControl("PnlTab1").Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Enabled = true;
            }
       }
