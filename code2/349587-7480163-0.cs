    private void form1CheckBox_CheckChanged(object sender, EventArgs e)
    {
        form2.ChangeCheck(form1CheckBox.Checked);
    }
    
    public void ChangeCheck(bool enable)
    {
        form1CheckBox.Checked = enable;
    }
