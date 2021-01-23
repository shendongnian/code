    MailMessage Msg = new MailMessage();
    // Sender e-mail address.
    Msg.From = txtFrom.Text;
    // Recipient e-mail address.
    Msg.To = txtTo.Text;
    Msg.Subject = txtSubject.Text;
    Msg.Body = txtBody.Text;
    // your remote SMTP server IP.
    SmtpMail.SmtpServer = "10.20.72.1";
    SmtpMail.Send(Msg);
    Msg = null;
    Page.RegisterStartupScript("UserMsg", "<script>alert('Mail sent thank you...');if(alert){ window.location='SendMail.aspx';}</script>");
    }
    catch (Exception ex)
    {
    Console.WriteLine("{0} Exception caught.", ex);
    }
