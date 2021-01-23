    /// <summary>
    /// Wrapper class for the System.Net.Mail objects
    /// </summary>
    public class SmtpMailMessage : IDisposable
    {
        #region declarations
        MailMessage Message;
        SmtpClient SmtpMailClient;
        #endregion
        #region constructors
        /// <summary>
        /// Default constructor for the SmtpMailMessage class
        /// </summary>
        public SmtpMailMessage()
        {
            //initialize the mail message
            Message = new MailMessage();
            Message.Priority = MailPriority.Normal;
            Message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;            
            Message.From = new MailAddress("operations@nesctc.com");           
            //initialize the smtp client
            SmtpMailClient = new SmtpClient();
            SmtpMailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpMailClient.Host = "192.168.0.21";
            SmtpMailClient.Port = 25;
        }
        /// <summary>
        /// Parameterized constructor for the SmtpMailMessage class. Allows for override of the default
        /// SMTP host and port number
        /// </summary>
        /// <param name="HostIP">The IP address of the exchange server</param>
        /// <param name="PortNumber">The port number for ingoing and outgoing SMTP messages</param>
        public SmtpMailMessage(string HostIP, int PortNumber) : this()
        {
            //override the smtp host value
            SmtpMailClient.Host = HostIP;
            //override the smtp port value
            SmtpMailClient.Port = PortNumber;
        }
        #endregion
        #region subject / body
        /// <summary>
        /// The body content of the mail message
        /// </summary>
        public string Body
        {
            get
            {
                return Message.Body;
            }
            set
            {
                Message.Body = value;
            }
        }
        /// <summary>
        /// the subject of the mail message
        /// </summary>
        public string Subject
        {
            get
            {
                return Message.Subject;
            }
            set
            {
                Message.Subject = value;
            }
        }
        #endregion
        #region mail type
        /// <summary>
        /// Gets or sets a value that determines whether the mail message
        /// should be formatted as HTML or text
        /// </summary>
        public bool IsHtmlMessage
        {
            get
            {
                return Message.IsBodyHtml;
            }
            set
            {
                Message.IsBodyHtml = value;
            }
        }
        #endregion
        #region sender
        /// <summary>
        /// Gets or sets the from address of this message
        /// </summary>
        public string From
        {
            get
            {
                return Message.From.Address;
            }
            set
            {
                Message.From = new MailAddress(value);
            }
        }
        #endregion
        #region recipients
        /// <summary>
        /// Gets the collection of recipients
        /// </summary>
        public MailAddressCollection To
        {
            get
            {
                return Message.To;
                
            }
        }
        /// <summary>
        /// Gets the collection of CC recipients 
        /// </summary>
        public MailAddressCollection CC
        {
            get
            {
                return Message.CC;
            }
        }
        /// <summary>
        /// Gets the collection of Bcc recipients
        /// </summary>
        public MailAddressCollection Bcc
        {
            get
            {
                return Message.Bcc;
            }
        }
        #endregion
        #region delivery notification
        /// <summary>
        /// Gets or sets the delivery notification settings for this message
        /// </summary>
        public DeliveryNotificationOptions DeliveryNotifications
        {
            get
            {
                return Message.DeliveryNotificationOptions;
            }
            set
            {
                Message.DeliveryNotificationOptions = value;
            }
        }
        #endregion
        #region priority
        /// <summary>
        /// Gets or sets the Priority of this message
        /// </summary>
        public MailPriority PriorityLevel
        {
            get
            {
                return Message.Priority;
            }
            set
            {
                Message.Priority = value;
            }
        }
        #endregion
        #region send methods
        /// <summary>
        /// Sends the message anonymously (without credentials)
        /// </summary>
        public void Send()
        {
            SmtpMailClient.Send(Message);
        }
        /// <summary>
        /// Sends the message with authorization from a network account   
        /// </summary>
        /// <param name="Username">The Windows username of the authorizing user</param>
        /// <param name="Password">The Windows password of the authorizing user</param>
        /// <param name="Domain">The domain name of the network to which the authorizing user belongs</param>
        public void Send(string Username, string Password, string Domain)
        {
            //attach a network credential to this message using the information passed into the method
            SmtpMailClient.Credentials = new NetworkCredential(Username, Password, Domain);
            //send the message
            SmtpMailClient.Send(Message);
        }
        #endregion
        #region IDisposable implementation
        ~SmtpMailMessage()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);            
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Message != null)
                    Message.Dispose();
                Message = null;                
                SmtpMailClient = null;
            }
        }
        #endregion        
    }
