    public static void DisableControls(this Control control, bool enable = false)
    {
        foreach (Control ctrl in control.Controls)
        {
            var wCtrl = ctrl as WebControl;
            if (wCtrl != null)
            {
                wCtrl.Enabled = enable;
            }
            if (ctrl.Controls.Count > 0)
                ctrl.DisableControls(enable);
        }
    }
    public static void EnableControls(this Control control)
    {
        control.DisableControls(true);
    }
