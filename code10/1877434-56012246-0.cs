    private void AllControls_Click(object sender, EventArgs e)
    {
        base.OnClick(e);
    }
    private void reclusiveControlLoop(ControlCollection Controls, Boolean Mode)
    {
        foreach (Control control in Controls)
        {
            if(control.Controls.Count > 0)
            {
                reclusiveControlLoop(control.Controls, Mode);
            }
            if(Mode)
            {
                control.Click += AllControls_Click;
            }
            else
            {
                control.Click -= AllControls_Click;
            }
        }
    }
