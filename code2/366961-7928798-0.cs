    private void ClearNumberEntries(ControlCollection controls)
    {
        foreach (Control ctrl in controls)
        {
            if (ctrl is NumberEntry)
            {
                ((NumberEntry)ctrl).Clear();
            }
            //if you are sure a NumberEntry can never have child controls that could also be of type NumberEntry you can put this in an else in stead
            ClearNumberEntries(ctrl.Controls);
        }
    }
