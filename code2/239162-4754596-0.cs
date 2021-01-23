        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            var messageBuffer = reply.CreateBufferedCopy(Int32.MaxValue);
            var message = messageBuffer.CreateMessage();
            
            using (var ms = new MemoryStream())
            {
                var xw = XmlWriter.Create(ms);
                message.WriteMessage(xw);
                Console.WriteLine(String.Format("Message size = {0}", ms.Length));
            }
        }
