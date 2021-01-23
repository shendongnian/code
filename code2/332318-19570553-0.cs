    using System.Collections.Generic;
    using System.Linq;
    using ActiveUp.Net.Mail;
    
    namespace GmailReadImapEmail
    {
        public class MailRepository
        {
            private Imap4Client client;
    
            public MailRepository(string mailServer, int port, bool ssl, string login, string password)
            {
                if (ssl)
                    Client.ConnectSsl(mailServer, port);
                else
                    Client.Connect(mailServer, port);
                Client.Login(login, password);
            }
    
            public IEnumerable<Message> GetAllMails(string mailBox)
            {
                return GetMails(mailBox, "ALL").Cast<Message>();
            }
    
            public IEnumerable<Message> GetUnreadMails(string mailBox)
            {
                return GetMails(mailBox, "UNSEEN").Cast<Message>();
            }
    
            protected Imap4Client Client
            {
                get { return client ?? (client = new Imap4Client()); }
            }
    
            private MessageCollection GetMails(string mailBox, string searchPhrase)
            {
                Mailbox mails = Client.SelectMailbox(mailBox);
                MessageCollection messages = mails.SearchParse(searchPhrase);
                return messages;
            }
        }
    }
