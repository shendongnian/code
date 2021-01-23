    public static void ClearTxtBox(Control control)
    {
        foreach (Control ctrl in control.Controls)
        {
            if (ctrl is TextBox)
                (TextBox)ctrl.Text = "";
             if (ctrl.HasControls())   
                 ClearTxtBox(ctrl);
        }
    }
