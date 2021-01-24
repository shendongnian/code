    // File name:  SendMail.cs
    using System;
    
    using MailKit.Net.Smtp;
    using MailKit;
    using MimeKit;
    
    namespace SendMail {
    	class Program
    	{
    		public static void Main (string[] args) {
    			using (var client = new SmtpClient ()) {
                    // Connect to the email service (Accept ssl certificate)
    				client.ServerCertificateValidationCallback = (s,c,h,e) => true;
    				client.Connect ("smtp.friends.com", 587, false);
    				// Optional step: Send user id, password, if the server requires authentication
    				client.Authenticate ("emailID", "emailPassword");
    
                    // Construct the email message
                    var message = new MimeMessage();
                    message.From.Add (new MailboxAddress ("Sender's Name", "sender-email@example.com"));
                    message.To.Add (new MailboxAddress ("Receiver's Name", "receiver-email@example.com"));
                    message.Subject = "Automatic email from the application";
                    message.Body = new TextPart ("plain") { Text = @"Hello Customer, Happy new year!"};
    
                    // Send the email
    				client.Send (message);
    
                    // Close the connection with the email server
    				client.Disconnect (true);
    			}
    		}
    	}
    }
