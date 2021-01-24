    private void button1_Click(object sender, EventArgs e)
            {
                 try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("Form@mail.com");
                mail.To.Add(txt_to.Text);
                mail.Subject = txt_subject.Text;
                mail.Body = txt_body.Text;
                System.Net.Mail.Attachment attachment = new 
              System.Net.Mail.Attachment(lbl_attach.Text);
                mail.Attachments.Add(attachment);
               mail.IsBodyHtml = true;
                  string htmlBody;
                  htmlBody = "Your html Design is here";
                //do the design as per requirements
                  mail.Body = htmlBody;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("form@gmail.com", "*****");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
            }
