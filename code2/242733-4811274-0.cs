    private void CleanForm(Control ctrl)
    {
        foreach (var c in ctrl.Controls)
        {
            if (c is TextBox)
            {
                ((TextBox)c).Text = String.Empty;
            }
            if( c.Controls.Count > 0)
            {
               CleanForm(c);
            }
        }
    }
