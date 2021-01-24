    String serviceAccountEmail = "yourserviceaccountmail";
    public GmailService GetService(string user_email_address)
        {
            var certificate = new X509Certificate2(@"yourkeyfile.p12", 
    "notasecret", X509KeyStorageFlags.Exportable);
            ServiceAccountCredential credential = new ServiceAccountCredential(
                       new ServiceAccountCredential.Initializer(serviceAccountEmail)
                       {
                           User = user_email_address,
                           Scopes = new[] { GmailService.Scope.MailGoogleCom }
                       }.FromCertificate(certificate));
            GmailService service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = AppName,
            });
            return service;
        }
