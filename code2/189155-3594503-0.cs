    private void Sleep_Click(object sender, EventArgs e)
    {
        bool retVal = Application.SetSuspendState(PowerState.Suspend, false, false);
        if (retVal == false)
            MessageBox.Show("Could not suspend the system.");
    }
    private void Hibernate_Click(object sender, EventArgs e)
    {
        bool retVal = Application.SetSuspendState(PowerState.Hibernate, false, false);
        if (retVal == false)
            MessageBox.Show("Could not hybernate the system.");
    }
