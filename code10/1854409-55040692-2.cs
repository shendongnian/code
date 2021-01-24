    if (RadioButtonList1.SelectedIndex > -1)
    {
            lbllogin.Visible = false;
            lblSignup.Visible = false;
            lblReset.Visible = false;
            string selected = RadioButtonList1.SelectedItem.Value;
            switch (selected)
            {
                case "signin":
                    lbllogin.Visible = true;
                    break;
                case "signup":
                    lblSignup.Visible = true;
                    break;
                case "reset":
                    lblReset.Visible = true;
                    break;
            }
    }
