    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    
    namespace mono_gmail
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			MailMessage mail = new MailMessage();
    			
    			mail.From = new MailAddress("my.name@gmail.com");
    			mail.To.Add("my.name@hotmail.com");
    			mail.Subject = "Test Mail";
    			mail.Body = "This is for testing SMTP mail from GMAIL";
    			
    			SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
    			smtpServer.Port = 587;
    			smtpServer.Credentials = new System.Net.NetworkCredential("my.name", "my.password");
    			smtpServer.EnableSsl = true;
    			ServicePointManager.ServerCertificateValidationCallback = 
    				delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
    					{ return true; };
    			smtpServer.Send(mail);
    		}
    	}
    }
