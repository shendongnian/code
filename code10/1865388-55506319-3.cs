    foreach (Control c in fraPParameters.Controls)
    {
        switch (c)
        {
            case TextBox textbox:
                textbox.Visible = false;
                textbox.ReadOnly = false;
                textbox.Text = string.Empty;
                textbox.Tag = string.Empty;
                //...
                break;
            case Label label:
                label.Visible = false;
                label.Text = string.Empty;
                label.Tag = string.Empty;
                //...
                break;
    
        }
    }
