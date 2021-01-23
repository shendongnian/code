    private void enableControls(Control.ControlCollection Controls)
    {
        foreach (Control c in Controls)
        {
            c.Enabled = true;
            if (c is MenuStrip)
            {
               foreach(var item in ((MenuStrip)c).Items)
               { 
                  item.enable;
               }
            }
            if (c.ControlCollection.Count > 0)
                enableControls(c.Controls);
        }
    }
