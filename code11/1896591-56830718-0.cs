private void btnSubmit_Click(object sender, EventArgs e)
{
    bool blnRes = Authentication.Authenicate(txtUsername.Text.Trim(),
                                             txtPassword.Text.Trim());
}
