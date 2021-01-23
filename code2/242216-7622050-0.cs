    protected override bool ProcessDialogKey(Keys keyData)
    {
        if (keyData == Keys.Escape)
        {
            this.AutoValidate = AutoValidate.Disable;
            cancelButton.PerformClick();
            this.AutoValidate = AutoValidate.Inherit;
            return true;
        }
        return base.ProcessDialogKey(keyData);
    }
