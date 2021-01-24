            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("abc@abc.com"); //From Email Id
            mailMessage.Subject = Subj; //Subject of Email
            mailMessage.Body = Message; //body or message of Email
            mailMessage.IsBodyHtml = true;
            List<string> ToEmailList = ToEmail.Split(',').ToList();
            ToEmailList.ForEach(x => mailMessage.To.Add(new MailAddress(x.ToString())));
            SmtpClient smtp = new SmtpClient("smtpout.secureserver.net", 25);
            smtp.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "abc@abc.com",
                Password = "abc@001"
            };
            smtp.EnableSsl = true;
