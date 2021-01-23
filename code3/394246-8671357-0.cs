    public class StackOverflow_8670954
    {
        [DataContract(Name = "Person", Namespace = "MyNamespace")]
        public class Person
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public int Age { get; set; }
            public override string ToString()
            {
                return string.Format("Person[Name={0},Age={1}]", Name, Age);
            }
        }
        [DataContract(Name = "Employee", Namespace = "MyNamespace")]
        public class Employee : Person
        {
            [DataMember]
            public int EmployeeId { get; set; }
            public override string ToString()
            {
                return string.Format("Employee[Id={0},Name={1}]", EmployeeId, Name);
            }
        }
        [ServiceContract]
        public interface ITest
        {
            [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
            [ServiceKnownType(typeof(Employee))]
            string PrintPerson(Person person);
        }
        public class Service : ITest
        {
            public string PrintPerson(Person person)
            {
                return person.ToString();
            }
        }
        static Binding GetBinding()
        {
            var result = new CustomBinding(new WebHttpBinding());
            for (int i = 0; i < result.Elements.Count; i++)
            {
                MessageEncodingBindingElement mebe = result.Elements[i] as MessageEncodingBindingElement;
                if (mebe != null)
                {
                    result.Elements[i] = new MyEncodingBindingElement(mebe);
                    break;
                }
            }
            return result;
        }
        class MyEncodingBindingElement : MessageEncodingBindingElement
        {
            MessageEncodingBindingElement inner;
            public MyEncodingBindingElement(MessageEncodingBindingElement inner)
            {
                this.inner = inner;
            }
            public override MessageEncoderFactory CreateMessageEncoderFactory()
            {
                return new MyEncoderFactory(this.inner.CreateMessageEncoderFactory());
            }
            public override MessageVersion MessageVersion
            {
                get { return this.inner.MessageVersion; }
                set { this.inner.MessageVersion = value; }
            }
            public override BindingElement Clone()
            {
                return new MyEncodingBindingElement(this.inner);
            }
            public override bool CanBuildChannelListener<TChannel>(BindingContext context)
            {
                return context.CanBuildInnerChannelListener<TChannel>();
            }
            public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
            {
                context.BindingParameters.Add(this);
                return context.BuildInnerChannelListener<TChannel>();
            }
            class MyEncoderFactory : MessageEncoderFactory
            {
                private MessageEncoderFactory inner;
                public MyEncoderFactory(MessageEncoderFactory inner)
                {
                    this.inner = inner;
                }
                public override MessageEncoder Encoder
                {
                    get { return new MyEncoder(this.inner.Encoder); }
                }
                public override MessageVersion MessageVersion
                {
                    get { return this.inner.MessageVersion; }
                }
            }
            class MyEncoder : MessageEncoder
            {
                private MessageEncoder inner;
                public MyEncoder(MessageEncoder inner)
                {
                    this.inner = inner;
                }
                public override string ContentType
                {
                    get { throw new NotImplementedException(); }
                }
                public override string MediaType
                {
                    get { throw new NotImplementedException(); }
                }
                public override MessageVersion MessageVersion
                {
                    get { throw new NotImplementedException(); }
                }
                public override bool IsContentTypeSupported(string contentType)
                {
                    return this.inner.IsContentTypeSupported(contentType);
                }
                public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
                {
                    if (IsJsonContentType(contentType))
                    {
                        // the encoder can also support other types of content (raw, xml), so we don't want to deal with those
                        MemoryStream writeStream = new MemoryStream();
                        XmlDictionaryWriter jsonWriter = JsonReaderWriterFactory.CreateJsonWriter(writeStream, Encoding.UTF8, false);
                        XmlDictionaryReader jsonReader = JsonReaderWriterFactory.CreateJsonReader(buffer.Array, buffer.Offset, buffer.Count, XmlDictionaryReaderQuotas.Max);
                        jsonWriter.WriteNode(jsonReader, true);
                        jsonWriter.Flush();
                        byte[] newBuffer = bufferManager.TakeBuffer(buffer.Offset + (int)writeStream.Position);
                        Array.Copy(writeStream.GetBuffer(), 0, newBuffer, buffer.Offset, (int)writeStream.Position);
                        bufferManager.ReturnBuffer(buffer.Array);
                        buffer = new ArraySegment<byte>(newBuffer, buffer.Offset, (int)writeStream.Position);
                        writeStream.Dispose();
                        jsonReader.Close();
                        jsonWriter.Close();
                    }
                    return this.inner.ReadMessage(buffer, bufferManager, contentType);
                }
                static bool IsJsonContentType(string contentType)
                {
                    return contentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase) ||
                        contentType.StartsWith("text/json", StringComparison.OrdinalIgnoreCase);
                }
                public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
                {
                    throw new NotSupportedException("Streamed transfer not supported");
                }
                public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
                {
                    return this.inner.WriteMessage(message, maxMessageSize, bufferManager, messageOffset);
                }
                public override void WriteMessage(Message message, Stream stream)
                {
                    throw new NotSupportedException("Streamed transfer not supported");
                }
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(ITest), GetBinding(), "").Behaviors.Add(new WebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            string[] inputs = new string[]
            {
                "{\"__type\":\"Employee:MyNamespace\",\"Age\":33,\"Name\":\"John\",\"EmployeeId\":123}",
                "{  \"__type\":\"Employee:MyNamespace\",\"Age\":33,\"Name\":\"John\",\"EmployeeId\":123}",
            };
            foreach (string input in inputs)
            {
                WebClient c = new WebClient();
                c.Headers[HttpRequestHeader.ContentType] = "application/json";
                Console.WriteLine(c.UploadString(baseAddress + "/PrintPerson", input));
            }
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
 
