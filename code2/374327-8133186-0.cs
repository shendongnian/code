    using Microsoft.Exchange.WebServices.Data;
    
    using System.Security.Cryptography.X509Certificates;
...
    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
    
    service.Url = new Uri(@"https://"+[Your exchange computer name like: abc.domain.com]+"/EWS/Exchange.asmx"); 
    
    //if have the ip you can get the computer name using the nslookup utility in command line. ->nslookup 192.168.0.90 
    
    ServicePointManager.ServerCertificateValidationCallback =
    					delegate(Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
    					{
    						return true;
    					};
    
    service.Credentials = new WebCredentials([User name: either email or domain account-but without the domain\], "password");
    
    EmailMessage mailmessage = new EmailMessage(service);
    
    mailmessage.From="me@something.com";
    
    mailmessage.ToRecipients.Add("someone@something.com");
    
    mailmessage.Subject = "Hello";
    
    mailmessage.Body = "World";
    
    mailmessage.Body.BodyType = BodyType.HTML; //or text
    
    mailmessage.Send();
