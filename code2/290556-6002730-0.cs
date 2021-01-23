    private bool labelDisabled = false;
    private void myLabel_Click(object sender, EventArgs e)
    {
        if (!labelDisabled)
        {
            this.ForeColor = SystemColors.ControlText;
        }
    }
