    private void ClearControls()
    {
        try
        {
            txtUserName.Text = string.Empty;
            //txtPassword.Text = string.Empty;
            txtFName.Text = string.Empty;
            txtMName.Text = string.Empty;
            txtLName.Text = string.Empty;
            lblUserType.Text = string.Empty;
        btnSave.Text = "Save";
        fnMessage(false, "");
    }
    catch (Exception ex)
    {
        fnMessage(true, ex.Message);
    }
