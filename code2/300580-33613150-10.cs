    SmtpClient smtp = new SmtpClient
    {
       Host = "smtp.office365.com",
       Port = 587,
       Credentials = new System.Net.NetworkCredential("Me@MyDomain.com", "Pa55w0rd"),
       EnableSsl = true
    };
    try { smtp.Send(message); }
    catch (Exception excp)
    {
       Console.Write(excp.Message);
       Console.ReadKey();
    }
