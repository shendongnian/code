        public void sendMail()
        {
            Console.WriteLine("Mail sending...");
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("From mail adress");
            ePosta.To.Add("To Mail Adress");
            ePosta.CC.Add("CCmail adress (optional)")
            ePosta.Attachments.Add(new Attachment(@"C:/xx/yy/abc.xlsx"));
            ePosta.Subject = "Subject here"
            ePosta.Body = "Body Message here"
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential(From mail adress, From mail password);
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            object userState = ePosta;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
            }
            catch
            {
                MessageBox.Show("Mail sending error");
            }
            Console.WriteLine("Mail sent");
