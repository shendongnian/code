    public static bool SendEmail(MailMessage message)
    {
        try
        {
            // call the full overload of if GetSMTPClient you want to override the default settings
            using (SmtpClient smtp = GetSMTPClient(true))
            {
                smtp.Send(message);
            }
            return true;
        }
        catch (Exception exception)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            return false;
        }
    }
    /// <summary>
    /// Gets the default SMTP Client (Gmail here)
    /// </summary>
    /// <param name="isSetAtWebConfig">Has all the settings been specified at web.config</param>
    /// <returns>Gets the default SMTP Client</returns>
    public static SmtpClient GetSMTPClient(bool isSetAtWebConfig)
    {
        try
        {
            SmtpClient client;
            if (isSetAtWebConfig)
            {
                client = new SmtpClient();
            }
            else
            {
                client = GetSMTPClient("smtp.gmail.com", 587, true,
                    SmtpDeliveryMethod.Network, false,
                    "someone@gmail.com", "somepass");
            }
            return client;
        }
        catch (Exception exception)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            throw;
        }
    }
    /// <summary>
    /// Gets the SMTP Client with custom settings default settings
    /// </summary>
    /// <param name="host">SMTP Host</param>
    /// <param name="port">SMTP Port</param>
    /// <param name="enableSSL">Has SMTP enabled SSL</param>
    /// <param name="delieveryMethod">SMTP Delivery Method</param>
    /// <param name="useDefaultCredentials">Is SMTP using Default Credentials</param>
    /// <param name="fromAddress">SMTP Client UserName</param>
    /// <param name="fromPassword">SMTP Client Password</param>
    /// <returns>Gets the new custom created SMTP Client</returns>
    public static SmtpClient GetSMTPClient(string host, int port, 
        bool enableSSL, SmtpDeliveryMethod delieveryMethod, 
        bool useDefaultCredentials, 
        string fromAddress, string fromPassword)
    {
        try
        {
            return new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = enableSSL,
                DeliveryMethod = delieveryMethod,
                UseDefaultCredentials = useDefaultCredentials,
                Credentials = new NetworkCredential(fromAddress, fromPassword)
            };
        }
        catch (Exception exception)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            throw;
        }
    }
