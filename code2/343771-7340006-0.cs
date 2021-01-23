    ThreadPool.QueueUserWorkItem(o => {
        using (SmtpClient client = new SmtpClient(...))
        {
            using (MailMessage mailMessage = new MailMessage(...))
            {
                client.Send(mailMessage, Tuple.Create(client, mailMessage));
            }
        }
    }); 
