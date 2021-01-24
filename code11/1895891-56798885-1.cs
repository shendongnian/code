using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    string mailServer;
     string recipient;
    public void Main()
    {
    try
    {
        mailServer = Dts.Variables["User::varServer"].Value.ToString();
        recipient = Dts.Variables["User::varRecipient"].Value.ToString();
    }
    catch
    {
        //catch exception
    }
    }
 private class sendEMail
 {
    public static void SendAutomatedEmail(string htmlString, string recipient = "user@domain.com")
    {
    
     try
     {
         
         MailMessage message = new MailMessage("it@domain.com", recipient);
         message .IsBodyHtml = true;
         message .Body = htmlString;
         message .Subject = "Test Email";
    
         SmtpClient client = new SmtpClient(mailServer);
         var AuthenticationDetails = new NetworkCredential("user@domain.com", "password");
         client.Credentials = AuthenticationDetails;
         client.Send(message);
     }
     catch (Exception e)
     {
         //catch exception
     }
    
    }
    
    }
    }
