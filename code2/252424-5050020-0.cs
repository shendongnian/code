    System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage("from@yahoo.com", "to@domain.com");
    message.Subject = "Hello";
    message.Body = "Some text";
    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.mail.yahoo.com", 465);
    smtp.EnableSsl = true;
    smtp.Credentials = new System.Net.NetworkCredential("yourusername", "yourpassword");
    smtp.UseDefaultCredentials = false;
    smtp.Send(message);
