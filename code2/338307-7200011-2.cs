       public static bool mailsent ;
       // I am not posting the mail sending code as its available every where.
        private void sendMailComplete(Object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
           
            MailMessage msd = e.UserState as MailMessage;
            if (!e.Cancelled) 
            {
                MessageBox.Show("Cancelled");
            }
             if (e.Error != null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                mailsent = true;
            }
        }
