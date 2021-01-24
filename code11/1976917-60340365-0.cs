    private void DisableCheckboxes(Control parentControl)
    {
        foreach (Control childControl in parentControl.Controls)
        {
            if (childControl is Panel childPanel)
            {
                DisableCheckboxes(childPanel);
            }
            else if (childControl is CheckBox childCheckBox)
            {
                childCheckBox.Enabled = false;
            }
        }
    }
