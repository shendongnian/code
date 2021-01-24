    namespace Services.Extension.ProtobufSerializationExtension
    {
        public class ProtobufDispatchFormatter : IDispatchMessageFormatter
        {
            OperationDescription operation;
            bool isVoidInput;
            bool isVoidOutput;
    
            public ProtobufDispatchFormatter(OperationDescription operation)
            {
                this.operation = operation;
                this.isVoidInput = operation.Messages[0].Body.Parts.Count == 0;
                this.isVoidOutput = operation.Messages.Count == 1 || operation.Messages[1].Body.ReturnValue.Type == typeof(void);
            }
    
            public void DeserializeRequest(Message message, object[] parameters)
            {
                if (!message.IsEmpty)
                {
                    XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
                    bodyReader.ReadStartElement("Binary");
                    byte[] rawBody = bodyReader.ReadContentAsBase64();
                    MemoryStream ms = new MemoryStream(rawBody);
    
                    using (StreamReader sr = new StreamReader(ms))
                        for (int i = 0; i < parameters.Length; i++)
                            parameters[i] = Serializer.Deserialize(operation.Messages[i].Body.Parts[i].Type, sr.BaseStream);
                }
            }
    
            public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
            {
                byte[] body;
    
                using (MemoryStream ms = new MemoryStream())
                using (StreamWriter sw = new StreamWriter(ms))
                {
                    Serializer.Serialize(sw.BaseStream, result);
                    sw.Flush();
                    body = ms.ToArray();
                }
    
                Message replyMessage = Message.CreateMessage(messageVersion, operation.Messages[1].Action, new RawBodyWriter(body));
                replyMessage.Properties.Add(WebBodyFormatMessageProperty.Name, new WebBodyFormatMessageProperty(WebContentFormat.Raw));
                return replyMessage;
            }
    
            class RawBodyWriter : BodyWriter
            {
                internal static readonly byte[] EmptyByteArray = new byte[0];
                byte[] content;
                public RawBodyWriter(byte[] content)
                  : base(true)
                {
                    this.content = content;
                }
    
                protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
                {
                    writer.WriteStartElement("Binary");
                    writer.WriteBase64(content, 0, content.Length);
                    writer.WriteEndElement();
                }
            }
        }
    }
