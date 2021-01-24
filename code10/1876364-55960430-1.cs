    private void button1_Click(object sender, EventArgs e)
    {
        var statusForm = new frmStatus();
        // Add an event handler for the second form's FormClosed event, and
        // put code in that event handler to re-enable controls on this form
        statusForm.FormClosed += frmStatus_FormClosed;
        // Disable our controls on this form and show the second form
        DisableControls();
        statusForm.Show();
    }
    private void frmStatus_FormClosed(object sender, FormClosedEventArgs e)
    {
        // When the second form closes, re-enable controls on this form
        EnableControls();
    }
    private void DisableControls()
    {
        foreach (Control control in Controls)
        {
            control.Enabled = false;
        }
    }
    private void EnableControls()
    {
        foreach (Control control in Controls)
        {
            control.Enabled = true;
        }
    }
