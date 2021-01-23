    public partial class Database
    {
        // ref: http://social.msdn.microsoft.com/Forums/en-US/0aa2a875-fd59-4f3e-a459-9f604b374749/how-do-i-use-certificate-based-authentication-with-data-services-client?forum=adodotnetdataservices
        private X509Certificate clientCertificate = null;
        public X509Certificate ClientCertificate
        {
            get
            {
                return clientCertificate;
            }
            set
            {
                if (value == null)
                {
                    // if the event has been hooked up before, we should remove it
                    if (clientCertificate != null)
                    {
                        SendingRequest -= OnSendingRequest_AddCertificate;
                    }
                }
                else
                {
                    // hook up the event if its being set to something non-null
                    if (clientCertificate == null)
                    {
                       SendingRequest += OnSendingRequest_AddCertificate;
                    }
                }
                clientCertificate = value;
            }
        }
        private void OnSendingRequest_AddCertificate(object sender, SendingRequestEventArgs args)
        {
            if (null != ClientCertificate)
            {
                (args.Request as HttpWebRequest).ClientCertificates.Add(ClientCertificate);
            }
        }
