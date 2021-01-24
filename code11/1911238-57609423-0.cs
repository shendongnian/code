    public class CorrectorInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            request = FilterMessage(request);
            return null;
        }
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            return;
        }
        private Message FilterMessage(Message originalMessage)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlWriter xmlWriter = XmlWriter.Create(memoryStream);
            originalMessage.WriteMessage(xmlWriter);
            xmlWriter.Flush();
            string body = Encoding.UTF8.GetString(memoryStream.ToArray());
            xmlWriter.Close();
            //Remove the ns1 prefix
            body = body.Replace("ns1:", "");
            body = body.Replace(":ns1", "");
            //remove the blank namespace 
            body = body.Replace(" xmlns=\"\"","");
            memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(body));
            XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateTextReader(memoryStream, new XmlDictionaryReaderQuotas());
            Message newMessage = Message.CreateMessage(xmlDictionaryReader, int.MaxValue, originalMessage.Version);
            newMessage.Properties.CopyProperties(originalMessage.Properties);
            return newMessage;
        }
    }
