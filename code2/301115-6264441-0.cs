    private void DiableTabStop(Control ctrl)
    {
        ctrl.TabStop = false;
        foreach (Control item in ctrl.Controls)
        {
            DiableTabStop(item);
        }
    }
