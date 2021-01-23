    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.ComponentModel;
    using CommandLine.Utility;
    
    namespace SmtpClientProgram
    {
        class Program
        {        
    
            static void Main(string[] args)
            {
                Arguments cmdLine = new Arguments(args);        
    
                SmtpClient mailer = new SmtpClient();
                
                // --ssl means we are using SSL/TLS
    
                mailer.EnableSsl = Convert.ToBoolean(cmdLine["ssl"]);
    
                // -host=smtp.gmail.com
    
                if (cmdLine["host"] != null)
                    mailer.Host = cmdLine["host"];
                else
                {
                    Console.WriteLine("Hostname must be specified");
                    return;
                }
    
                // -port=25
    
                if (cmdLine["port"] != null)
                    try
                    {
                        mailer.Port = Convert.ToInt32(cmdLine["port"]);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Port must be a number between 1 and 65535");
                    }
                else
                    mailer.Port = 25;
    
                // -user= -password=
                if (cmdLine["user"] != null && cmdLine["password"] != null)
                {                
                    mailer.Credentials = new NetworkCredential(cmdLine["user"], cmdLine["password"]);
                }
    
                try
                {
                    MailMessage mail = new MailMessage();
    
                    mail.From = new MailAddress(cmdLine["from"], cmdLine["name"]);
    
                    if (cmdLine["to1"] != null)
                        mail.To.Add(cmdLine["to1"]);
                    else
                        Console.WriteLine("Must specify first TO address");
                    
                    if (cmdLine["to2"] != null)
                        mail.To.Add(cmdLine["to2"]);
    
                    if (cmdLine["to3"] != null)
                        mail.To.Add(cmdLine["to3"]);
    
                    if (cmdLine["subject"] != null)
                        mail.Subject = cmdLine["subject"];
    
                    if (cmdLine["body"] != null)
                        mail.Body = cmdLine["body"];
    
                    mailer.Send(mail);
    
                    //mailer.Send(cmdLine["from"], cmdLine["to"], cmdLine["subject"], cmdLine["body"]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                Console.WriteLine("Success");            
            }
        }
    }
