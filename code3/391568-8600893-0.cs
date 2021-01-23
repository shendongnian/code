    public void MakeVisible(Control control)
    {
        if(control.HasChildren)
        {
            foreach (Control child in control.Controls)
            {
                MakeVisible(child);
            }
        }
        control.Visible = true;
    }
