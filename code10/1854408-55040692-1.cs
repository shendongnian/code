    if (RadioButtonList1.SelectedIndex > -1)
    {
            lbllogin.Visible = false;
            lblSignup.Visible = false;
            lblReset.Visible = false;
            string selected = RadioButtonList1.SelectedItem.Text;
            switch(selected)
            {
                case "Sign in":
                    lbllogin.Visible = true;
                    break;
                case "Sign up":
                    lblSignup.Visible = true;
                    break;
                case "Reset":
                    lblReset.Visible = true;
                    break;
            }
            
    }
