C#
public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
        {
            byte[] msgContents = new byte[buffer.Count];
            Array.Copy(buffer.Array, buffer.Offset, msgContents, 0, msgContents.Length);
            bufferManager.ReturnBuffer(buffer.Array);
            MemoryStream stream = new MemoryStream(msgContents);
            var doc = new XmlDocument {PreserveWhitespace = true};
            doc.Load(stream);
            XmlNode envNode = doc.GetElementsByTagName("S:Envelope")[0];
            XmlNode headerNode = doc.GetElementsByTagName("S:Header")[0];
            XmlNode bodyNode = doc.GetElementsByTagName("S:Body")[0];
            if (envNode.Attributes != null && bodyNode.Attributes != null)
            {
                envNode.Attributes.RemoveAll();
                headerNode.RemoveAll();
                bodyNode.Attributes.RemoveAll();
            }
            stream = new MemoryStream();
            doc.Save(stream);
            stream.Position = 0;
            return Message.CreateMessage(XmlReader.Create(stream), int.MaxValue, MessageVersion);
        }
