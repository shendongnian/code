    private void form2CheckBox_CheckChanged(object sender, EventArgs e)
    {
        ((Form1)this.Owner).ChangeCheck(form2CheckBox.Checked);
    }
    
    public void ChangeCheck(bool enable)
    {
        form2CheckBox.Checked = enable;
    }
