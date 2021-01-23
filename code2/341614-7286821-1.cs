    private void async YourButton_Click(object sender, EventArgs args)
    {
       // Do authentication stuff here.
       lbl_authenticationProcess.Text = "Credentials have been verified authentic...";
       await Task.Delay(3000); // TaskEx.Delay in CTP
       lbl_authenticationProcess.Visible = false;
    }
