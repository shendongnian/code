    private void enableControls(Control.ControlCollection Controls)
    {
        foreach (Control c in Controls)
        {
            c.Enabled = true;
            if (c.HasChildren)
                enableControls(c.Controls);
        }
    }
