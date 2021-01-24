    private void button1_Click(object sender, EventArgs e)
    {
        var statusForm = new frmStatus();
        // Add an event handler for the second form's FormClosed event, and
        // put code in that event handler to re-enable controls on this form
        statusForm.FormClosed += statusForm_FormClosed;
        // Disable our controls on this form and show the second form
        DisableForm();
        statusForm.Show();
    }
    private void statusForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        // When the second form closes, re-enable controls on this form
        EnableForm();
    }
    private void DisableForm()
    {
        this.gridData.Enabled = false;
        this.txtLocation.Enabled = false;
        this.txtSupplier.Enabled = false;
        this.txtItem.Enabled = false;
    }
    public void EnableForm() 
    {
        this.gridData.Enabled = true;
        this.txtLocation.Enabled = true;
        this.txtSupplier.Enabled = true;
        this.txtItem.Enabled = true;
        this.FillTable("", "", "");
    }
