     public class MyMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message request, object correlationState)
        {
            //http://blogs.msdn.com/b/carlosfigueira/archive/2011/04/19/wcf-extensibility-message-inspectors.aspx
            MemoryStream ms = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(ms);
            request.WriteMessage(writer); // the message was consumed here
            writer.Flush();
            ms.Position = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ms);
            this.ReadMessage(xmlDoc);
            //Now recreating the message
            ms = new MemoryStream();
            xmlDoc.Save(ms);
            ms.Position = 0;
            XmlReader reader = XmlReader.Create(ms);
            Message newMessage = Message.CreateMessage(reader, int.MaxValue, request.Version);
            newMessage.Properties.CopyProperties(request.Properties);
            request = newMessage;
        }
        private void ReadMessage(XmlDocument xmlDoc)
        {
            XmlNode v1 = xmlDoc.GetElementsByTagName("XPAth");
            //Actual Namespace in XML, which should be used in Proxy Class
            string namespaceURIForObjectInXML = v1.NamespaceURI;
        }
        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
           
        }
        
    }
