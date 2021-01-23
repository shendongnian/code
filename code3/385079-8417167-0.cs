    protected void Btn_SendMail_Click(object sender, EventArgs e)
    {
        MailMessage mailObj = new MailMessage(
            txtFrom.Text, txtTo.Text, txtSubject.Text, txtBody.Text);
        SmtpClient SMTPServer = new SmtpClient("localhost");
        try
        {
           SMTPServer.Send(mailObj);
        }
            catch (Exception ex)
        { 
            Label1.Text = ex.ToString();
        }
    }
