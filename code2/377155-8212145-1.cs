    string datalink;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TextBox2.Text = Request.QueryString[0];
            datalink = this.TextBox2.Text;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Create the mail message
                string strFrom = "abcd@gmail.com";
                string strTo = TextBox1.Text;
                string strCC = TextBox3.Text;
                string strSubject = "Document shared";
                string strMsg = " The document has been shared with you. Please check the attachment.";
                string myPath = @"C:\Visual Studio 2008\Data\";
                MailMessage objMailMsg = new MailMessage(strFrom, strTo);
    
                objMailMsg.BodyEncoding = Encoding.UTF8;
                objMailMsg.Subject = strSubject;
                objMailMsg.Body = strMsg;
                objMailMsg.CC.Add(strCC);
                Attachment at = new Attachment(myPath + datalink);
                objMailMsg.Attachments.Add(at);
                objMailMsg.Priority = MailPriority.High;
                objMailMsg.IsBodyHtml = true;
    
                SmtpClient smtp = new SmtpClient();
                smtp.EnableSsl = true;
                smtp.Send(objMailMsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
