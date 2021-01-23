    private void async YourButton_Click(object sender, EventArgs args)
    {
       // Do authentication stuff here.
       lbl_authenticationProcess.Text = "Credentials have been verified authentic...";
       await TaskEx.Delay(3000); // Task.Delay in C# 5.0
       lbl_authenticationProcess.Visible = false;
    }
