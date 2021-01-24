        protected static void MimeProcessor(MemoryStream stream)
        {
            try
            {
                var parser = new MimeParser(stream, MimeFormat.Default);
                var message = parser.ParseMessage();
                var multipart = message.Body as Multipart;
                //Found the Attachment as Message Part
                var OriginalMessage = multipart.ToList().LastOrDefault();
                if (OriginalMessage is MessagePart)
                {
                    using (var memory = new MemoryStream())
                    {
                        ((MessagePart)OriginalMessage).Message.WriteTo(memory);
                        var bytes = memory.ToArray();
                        File.WriteAllBytes("C:\\Test\\TestMessage.eml", bytes);
                    }
                }
 
            }
            catch (Exception)
            {
                
                throw;
            }
        }
