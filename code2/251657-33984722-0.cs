    using Mailling;
    
        MailController m = new MailController("username", "password");
    
        private void Form1_Load(object sender, EventArgs e)
        {
            //Gett Mails
            List<Mail> mails = m.GetAllMails();
            foreach (Mail item in mails)
            {
                MessageBox.Show("From : "+item.From+"\n"+"Title: "+item.Title+"\n"+"Summary : "+item.Summary);
            }
            
            //SendMail
            m.SendMail("username", "password", "title", "summary");
        }
