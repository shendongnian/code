    public static void SetEnableOnAllControls(Control parentControl, bool enable)
    {
        parentControl.Enabled = enable;
        foreach (Control control in parentControl.Controls)
            SetEnableOnAllControls(control, enable);
    }
    [...]
    // inside your form:
    SetEnableOnAllControls(this, false);
