    private RadioButton GetSelectedRadioButton(string groupName)
    {
        return GetSelectedRadioButton(Controls, groupName);
    }
    private RadioButton GetSelectedRadioButton(ControlCollection controls, string groupName)
    {
        RadioButton retval = null;
        if (controls != null)
        {
            foreach (Control control in controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radioButton = (RadioButton) control;
                    if (radioButton.GroupName == groupName && radioButton.Checked)
                    {
                        retval = radioButton;
                        break;
                    }
                }
                if (retval == null)
                {
                    retval = GetSelectedRadioButton(control.Controls, groupName);
                }
            }
        }
        return retval;
    }
