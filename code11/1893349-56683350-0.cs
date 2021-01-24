    using System;
    using System.Net;
    using System.Net.Mail;
    
    namespace BTCSharp
    {
        public abstract class Mail
        {
            static SmtpClient Client = new SmtpClient();
            private static string From;
    
            public static void Login(string xHost, int xPort, string xUsername, string xPassword, bool xSsl)
            {
                //LOGIN
                Client.Host = xHost;
                Client.Port = xPort;
                Client.DeliveryMethod = SmtpDeliveryMethod.Network;
    
                //CREDENTIALS
                Client.UseDefaultCredentials = false;
                Client.Credentials = new NetworkCredential(xUsername, xPassword);
                Client.Timeout = 30000;
                Client.EnableSsl = xSsl;
                if (xUsername.Contains("@")) From = xUsername;
            }
            public static void Login(string xHost, int xPort, string xAddress, string xUsername, string xPassword, bool xSsl)
            {
                //LOGIN WHERE USERNAME DIFFERENT TO MAIL ADDRESS
                Login(xHost, xPort, xUsername, xPassword, xSsl);
                From = xAddress;
            }
    
            public static bool Send(string xFrom, string xTo, string xSubject, string xBody, params Attachment[] xAttachments)
            {
                //SEND MAIL
                if (Client.Credentials == null) { BTCSharp.Client.Console("[Mail] Error: login needed"); return false; }
                try
                {
                    MailMessage mail = new MailMessage(xFrom, xTo, xSubject, xBody);
                    foreach (Attachment attachment in xAttachments) mail.Attachments.Add(attachment);
                    Client.Send(mail);
                    return true;
                }
                catch (Exception e)
                {
                    //FOR GMAIL VISIT: https://myaccount.google.com/lesssecureapps
                    Console.WriteLine("[Mail] Error: " + e.Message);
                    return false;
                }
            }
    
            public static void Send(string xTo, string xSubject, string xBody, params Attachment[] xAttachments)
            {
                //SEND MAIL
                Send(From, xTo, xSubject, xBody, xAttachments);
            }
        }
    }
