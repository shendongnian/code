    private void RecusiceControls(ControlCollection controls)
            {
                foreach (Control control in controls)
                {
                    RecusiceControls((ControlCollection)control.Controls);
                    if (control is Button) // whatever the control is you are looking for
                    {
                    }
                }
            }
