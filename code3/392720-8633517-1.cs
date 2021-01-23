     public static void SendEmail(string Body)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(Session["Email"].Tostring());
                message.To.Add(ConfigurationSettings.AppSettings["RequesEmail"].ToString());
                message.Subject = "Request from " + SessionFactory.CurrentCompany.CompanyName + " to add a new supplier";
                message.IsBodyHtml = true;
                message.Body = Body;
    
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = true;
    
                smtpClient.Host = ConfigurationSettings.AppSettings["SMTP"].ToString();
                smtpClient.Port = Convert.ToInt32(ConfigurationSettings.AppSettings["PORT"].ToString());
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["USERNAME"].ToString(), ConfigurationSettings.AppSettings["PASSWORD"].ToString());
                smtpClient.Send(message);
            }
