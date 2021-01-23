            String frmyahoo = "fromid@yahoo.com";                        //Replace your yahoo mail id
            String frmpwd = "fromidpwd";                                 //Replace your yahoo mail pwd
            String toId = txtTo.Text;
            String ccId = txtCc.Text;
            String bccId = txtBcc.Text;
            String msgsubject = txtSubject.Text;
            String mailContent = txtContent.Text;
    
            try
            {
                MailMessage msg = new MailMessage();
    
                msg.To.Add(toId);
                MailAddress frmAdd = new MailAddress(frmyahoo);
                msg.From = frmAdd;
    
                //Check user enter CC address or not
                if (ccId != "")
                {
                    msg.CC.Add(ccId);
                }
                //Check user enter BCC address or not
                if (bccId != "")
                {
                    msg.Bcc.Add(bccId);
                }
                msg.Subject = msgsubject;
                //Check for attachment is there
                if (FileUpload1.HasFile)
                {
                    msg.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, FileUpload1.FileName));
                }
                msg.IsBodyHtml = true;
                msg.Body = mailContent;
    
                SmtpClient mailClient = new SmtpClient("smtp.mail.yahoo.com", 25);
                NetworkCredential NetCrd = new NetworkCredential(frmyahoo, frmpwd);
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = NetCrd;
                mailClient.EnableSsl = false;
                mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                mailClient.Send(msg);
    
                clear();
                Label1.Text = "Mail Sent Successfully";
            }
            catch (Exception ex)
            {
                Label1.Text = "Unable to send Mail Please try again later";
            }
        }
