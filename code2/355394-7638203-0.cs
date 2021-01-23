        private void SaveEmailToDisk(MailMessage message, string saveTo)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("To: {0}\n", String.Join("; ", message.To.Select(m => m.Address).ToArray()));
            builder.AppendFormat("From: {0}\n",message.From.Address);
            builder.AppendFormat("Subject: {0}", message.Subject);
            builder.AppendFormat("Body: {0}", message.Body);
            File.WriteAllText(saveTo, builder.ToString());
        }
