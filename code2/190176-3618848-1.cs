    public static void SetEnableOnAllChildControls(Control parentControl, bool enable)
    {
        foreach (Control control in parentControl.Controls)
        {
            control.Enabled = enable;
            SetEnableOnAllChildControls(control, enable);
        }
    }
