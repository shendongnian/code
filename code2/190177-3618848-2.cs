    public static void SetReadOnlyOnAllControls(Control parentControl, bool readOnly)
    {
        if (parentControl is TextBoxBase)
            ((TextBoxBase) parentControl).ReadOnly = readOnly;
        foreach (Control control in parentControl.Controls)
            SetReadOnlyOnAllControls(control, readOnly);
    }
