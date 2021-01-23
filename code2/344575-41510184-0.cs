       using System;
       using System.Collections.Generic;
       using System.Text;
       using System.IO;
       using EAGetMail; //add EAGetMail namespace
       namespace receiveemail
       {
           class Program
           {
               static void Main(string[] args)
               {
            // Create a folder named "inbox" under current directory
            // to save the email retrie enter code here ved.
            string curpath = Directory.GetCurrentDirectory();
            string mailbox = String.Format("{0}\\inbox", curpath);
            // If the folder is not existed, create it.
            if (!Directory.Exists(mailbox))
            {
                Directory.CreateDirectory(mailbox);
            }
            // Gmail IMAP4 server is "imap.gmail.com"
            MailServer oServer = new MailServer("imap.gmail.com",
                        "gmailid@gmail.com", "yourpassword", ServerProtocol.Imap4 );
            MailClient oClient = new MailClient("TryIt");
            // Set SSL connection,
            oServer.SSLConnection = true;
            // Set 993 IMAP4 port
            oServer.Port = 993;
            try
            {
                oClient.Connect(oServer);
                MailInfo[] infos = oClient.GetMailInfos();
                for (int i = 0; i < infos.Length; i++)
                {
                    MailInfo info = infos[i];
                    Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}",
                        info.Index, info.Size, info.UIDL);
                    // Download email from GMail IMAP4 server
                    Mail oMail = oClient.GetMail(info);
                    Console.WriteLine("From: {0}", oMail.From.ToString());
                    Console.WriteLine("Subject: {0}\r\n", oMail.Subject);
                    // Generate an email file name based on date time.
                    System.DateTime d = System.DateTime.Now;
                    System.Globalization.CultureInfo cur = new
                        System.Globalization.CultureInfo("en-US");
                    string sdate = d.ToString("yyyyMMddHHmmss", cur);
                    string fileName = String.Format("{0}\\{1}{2}{3}.eml",
                        mailbox, sdate, d.Millisecond.ToString("d3"), i);
                    // Save email to local disk
                    oMail.SaveAs(fileName, true);
                    // Mark email as deleted in GMail account.
                    oClient.Delete(info);
                }
                // Quit and purge emails marked as deleted from Gmail IMAP4 server.
                oClient.Quit();
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
            }
        }
    }
}
