    public void ApplyButtonClicked(object sender, EventArgs e)
    {
        //Set any properties that were changed in the dialog box here
        //...
    }
    
    public void OKButtonClicked(object sender, EventArgs e)
    {
        //"Click" the Apply button, to apply any properties that were changed
        ApplyButton.PerformClick();
    
        //Close the dialog
        this.DialogResult = DialogResult.OK;
    }
