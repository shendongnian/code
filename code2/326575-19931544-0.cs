            // CREATE NEW EMAIL OBJECT
            ContactUs.Core.Email oEmail = new ContactUs.Core.Email();
            // EMAIL SMTP SERVER INFORMATION
            oEmail.SmtpServer = "Server";
            oEmail.SetAuthentication("contact@Server.com", "Password");
            // EMAIL INFORMATION
            oEmail.From = "contact@Server.com";
            oEmail.To = "RecipientEmail";
            oEmail.Subject = this.txtMessage.Text;
            oEmail.Message = strMessage;
            // SEND EMAIL
            oEmail.HtmlFormat = true;
            oEmail.Send();
