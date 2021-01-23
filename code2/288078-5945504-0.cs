    public static void SendEmail(string messageText, string subjectText,
            string fromAddress, string toAddress, string ccAddress,
            string bccAddress, string hostName, string attachments,
            string userName, string password)
        {
            try
            {
            string[] toAddressList = toAddress.Split(';');
            string[] ccAddressList = ccAddress.Split(';');
            string[] bccAddressList = bccAddress.Split(';');
            string[] attachmentList = attachments.Split(';');
            MailMessage mail = new MailMessage();
            //Loads the To address field
            foreach (string address in toAddressList)
            {
                if (address.Length > 0)
                {
                    mail.To.Add(address);
                }
            }
                //Loads the CC address field
                foreach (string address in ccAddressList)
                {
                    if (address.Length > 0)
                    {
                        mail.CC.Add(address);
                    }
                }
                //Loads the BCC address field
                foreach (string address in bccAddressList)
                {
                    if (address.Length > 0)
                    {
                        mail.Bcc.Add(address);
                    }
                }
                //Loads the attachment list
                foreach (string attachment in attachmentList)
                {
                    if (attachment.Length > 0)
                    {
                        mail.Attachments.Add(new Attachment(attachment));
                    }
                }
                mail.From = new MailAddress(fromAddress);
                mail.Subject = subjectText;
                string Body = messageText;
                mail.Body = Body;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = hostName;
                smtp.Credentials = new System.Net.NetworkCredential(userName,password);
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mail);
                mail.Dispose();
                smtp.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
