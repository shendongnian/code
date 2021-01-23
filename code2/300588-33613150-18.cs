    using System;
    using System.Net.Mail;
    
    namespace ConsoleApplication1
    {
       class Program
       {
          static void Main(string[] args)
          {
             using (
                MailMessage message = new MailMessage
                {
                   To = { new MailAddress("Recipient1@Recipient1Domain.com", "Recipient 1") },
                   Sender = new MailAddress("Me@MyDomain.com", "Me"),
                   From = new MailAddress("Client@ClientDomain.com", "Client"),
                   Subject=".net Testing"
                   Body="Testing .net emailing",
                   IsBodyHtml=true,
                }
             )
             {
                using (
                   SmtpClient smtp = new SmtpClient
                   {
                      Host = "smtp.office365.com",
                      Port = 587,
                      Credentials = new System.Net.NetworkCredential("Me@MyDomain.com", "Pa55w0rd"),
                      EnableSsl = true
                   }
                )
                {
                   try { smtp.Send(message); }
                   catch (Exception excp)
                   {
                      Console.Write(excp.Message);
                      Console.ReadKey();
                   }
                }
             }
          }
       }
    }
