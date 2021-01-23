    using System;
    using System.IO;
    using System.Net.Mail;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Xsl;
    
    class Program
    {
        static void Main()
        {
            try
            {
                var xPathDoc = new XPathDocument(@"C:\Test\svnlog.xml");
                var xslTrans = new XslCompiledTransform();
                xslTrans.Load(@"C:\Test\svnlog.xsl");
                using (var writer = XmlWriter.Create(@"C:\Test\CommitReport.html"))
                {
                    xslTrans.Transform(xPathDoc, null, writer);
                }
    
                var mail = new MailMessage();
                mail.To.Add(new MailAddress("pqr@dna.com"));
                mail.From = new MailAddress("abc@bac.com");
                mail.Subject = "Commit Error Report";
                mail.IsBodyHtml = true;
                mail.Body = File.ReadAllText(@"C:\Test\CommitReport.html");
    
                using (var smtpClient = new SmtpClient("smtp.yourhost.com"))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
