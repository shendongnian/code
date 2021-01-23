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
