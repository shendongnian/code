     public class MyMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message request, object correlationState)
        {
            
            MemoryStream ms = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(ms);
            request.WriteMessage(writer); 
            writer.Flush();
            ms.Position = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ms);
            this.ReadMessage(xmlDoc);
            
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
