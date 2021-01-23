    System.Net.Mail.SmtpClient sc = new SmtpClient();
    sc.Host = host;
    sc.Port = port;
    sc.Credentials = new NetworkCredential(username, password);
    sc.Send(mm);
