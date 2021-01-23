    /// <summary>
    /// Handle "Enabled" property of a set of Controls (and all of the included child controls through recursivity)
    /// By default it disable all, making all read-only, but it can also be uset to re-enable everything, using the "enable" parameter 
    /// </summary>
    /// <param name="controls">Set of controls to be handled. It could be the entire Page.Controls set or all of the childs of a given control (property "Controls" of any Control-derived class)</param>
    /// <param name="enable">Desired value of the property "enable" of each control. </param>
    public static void DisableControls(ControlCollection controls, bool enable = false)
    {
        foreach (Control control in controls)
        {
            var wCtrl = control as WebControl;
            if (wCtrl != null)
            {
                wCtrl.Enabled = enable;
            }
            if (control.Controls.Count > 0)
                DisableControls(control.Controls, enable);
        }
    }
    /// <summary>
    /// Enable a set of Controls (and all of the included child controls through recursivity).
    /// Friendly name for DisableControls(controls, true), that achieve the same result.
    /// </summary>
    /// <param name="Controls">Set of controls to be handled. It could be the entire Page.Controls set or all of the childs of a given control (property "Controls" of any Control-derived class)</param>
    public static void EnableControls(ControlCollection controls)
    {
        DisableControls(controls, true);
    }
