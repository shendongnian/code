    foreach (Control c in fraPParameters.Controls)
    {
        var lbl = c as Label;
        var box = c as TextBox;
        if (lbl != null)
        {
            lbl.Visible = false;
            lbl.Text = string.Empty;
            lbl.Tag = string.Empty;
            tt.SetToolTip(c, null);
        }
        
        if (box != null)
        {
            box.Visible = false;
            box.ReadOnly = false;
            box.Text = string.Empty;
            box.Tag = string.Empty;
            tt.SetToolTip(c, null);
            box.BackColor = Color.White;
        }
    }
