    foreach(Control ctl in this.Controls)
    {
        TextBox tbx = ctl as TextBox;
        if(tbx != null)
        {
             tbx.Text = String.Empty;
        }
    }
