    var Enable = (Control c) =>
                 {
                     c.Enabled = true;
                     if(c.Controls != null)
                         foreach(Control c2 in c.Controls)
                             Enable(c2);
                 }
    Enable(YourForm);
