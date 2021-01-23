    public class GmailClient : IDisposable
    {
        private const string GmailUri = "https://mail.google.com/mail/feed/atom";
        private string _userName;
        private string _password;
        private GmailList _newMailList;
        public GmailClient(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }
        /// <summary>
        /// I'd prefer to return the generic list here instead of using the GetMailItem 
        /// method to get individual items, but javascript doesn't play nice with generics.
        /// </summary>
        public void GetUnreadMail()
        {
            try 
            {
                // Get the XML feed from mail.google.com
                XmlElement element = GetFeedXml();
                if (element != null)
                {
                    // Deserialize the transformed XML into a generic list of GmailItem objects
                    XmlNodeReader reader = new XmlNodeReader(element);
                    XmlSerializer serializer = new XmlSerializer(typeof(GmailList));
                    _newMailList = serializer.Deserialize(reader) as GmailList;
                }
            }
            catch { }
        }
        /// <summary>
        /// The number of items in the unread mail collection
        /// </summary>
        public object UnreadMailCount
        {
            get 
            {
                if (_newMailList != null)
                {
                    return _newMailList.Count;
                }
                else 
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// Returns the GmailItem at the specified index
        /// </summary>
        /// <param name="index">Index if the mail item to return</param>
        public GmailItem GetMailItem(int index)
        {
            if (_newMailList == null || index < 0 || index > _newMailList.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return _newMailList[index];
        }
        /// <summary>
        /// Get the XML feed from google and transform it into a deserializable format
        /// </summary>
        private XmlElement GetFeedXml()
        {
            try
            {
                // Create a web request to get the xml feed
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GmailUri);
                request.Method = "GET";
                request.Credentials = new NetworkCredential(_userName, _password);
                XmlDocument xml = null;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // If the request/response is successful
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // Get the response stream containing the xml
                    using (XmlTextReader reader = new XmlTextReader(response.GetResponseStream()))
                    {
                        // Load the XSLT document (it's an embedded resource)
                        byte[] data = Encoding.ASCII.GetBytes(GmailReader.Properties.Resources.GmailTransform);
                        using (MemoryStream xsltStream = new MemoryStream(data))
                        {
                            // Create a text reader with the XSLT document
                            XmlTextReader stylesheetReader = new XmlTextReader(xsltStream);
                            XslCompiledTransform transform = new XslCompiledTransform();
                            transform.Load(stylesheetReader);
                            // Run an XSLT transform on the google feed to get an xml structure 
                            // that can be deserialized into a GmailList object
                            using (MemoryStream ms = new MemoryStream())
                            {
                                transform.Transform(new XPathDocument(reader), null, ms);
                                ms.Seek(0, SeekOrigin.Begin);
                                xml = new XmlDocument();
                                // Load the transformed xml
                                xml.Load(ms);
                            }
                        }
                    }
                }
                response.Close();
                return xml.DocumentElement;
            }
            catch
            {
            }
            return null;
        }
        #region IDisposable Members
        public void Dispose()
        {
            // Nothing to do here.
        }
        #endregion
    }
