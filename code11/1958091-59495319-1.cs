    mtTextField.EditingDidBegin += MtTextField_EditingDidBegin;
    mtTextField.EditingDidEnd += MtTextField_EditingDidEnd;
               
    private void MtTextField_EditingDidEnd(object sender, EventArgs e)
    {
        mtTextField.TextColor = UIColor.Gray;
    }
    
    private void MtTextField_EditingDidBegin(object sender, EventArgs e)
    {
        mtTextField.TextColor = UIColor.Blue;
    }
