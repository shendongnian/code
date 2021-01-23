    private void btnDelete_Click(object sender, EventArgs e)
    {
        bool isValidEmail = false;
        try
        {
            var email = new MailAddress(txtEmail.Text);
            isValidEmail = true;
        {
        catch
        {
        }
    }
