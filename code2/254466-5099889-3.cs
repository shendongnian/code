    /// <summary>
    /// Extension to allow logging of SOAP request and response xml.
    /// </summary>
    public class SoapLogger : SoapExtension
    {
        private MemoryStream copyStream;
        public override Stream ChainStream(Stream stream)
        {
            this.copyStream = new MemoryStream();
            return new CopyStream(stream, copyStream);
        }
        public override object GetInitializer(Type serviceType)
        {
            return null;
        }
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return null;
        }
        public override void Initialize(object initializer)
        {
        }
        public override void ProcessMessage(SoapMessage message)
        {
            switch (message.Stage)
            {
                case SoapMessageStage.AfterSerialize:
                case SoapMessageStage.AfterDeserialize:
                    Log(message);
                    break;
            }
        }
        private void Log(SoapMessage message)
        {
            string messageType;
            if (message.Stage == SoapMessageStage.AfterDeserialize)
            {
                messageType = message is SoapServerMessage ? "SoapRequest" : "SoapResponse";
            }
            else
            {
                messageType = message is SoapServerMessage ? "SoapResponse" : "SoapRequest";
            }
            StreamReader reader = new StreamReader(new MemoryStream(this.copyStream.ToArray()));
            Logger.Log(string.Format(
                "{0} ({1}):\r\n{2}",
                messageType,
                message.MethodInfo.Name,
                reader.ReadToEnd()
            ));
        }
    }
    /// <summary>
    /// Implementation of a stream that wraps an existing stream while copying anything written
    /// or read to another stream.
    /// </summary>
    public class CopyStream : Stream
    {
        public Stream BaseStream
        {
            get
            {
                return this.baseStream;
            }
        }
        private Stream baseStream;
        public Stream OtherStream
        {
            get
            {
                return this.otherStream;
            }
        }
        private Stream otherStream;
        public CopyStream(Stream BaseStream, Stream OtherStream)
        {
            if (BaseStream == null)
            {
                throw new ArgumentNullException("BaseStream");
            }
            if (OtherStream == null)
            {
                throw new ArgumentNullException("OtherStream");
            }
            this.baseStream = BaseStream;
            this.otherStream = OtherStream;
        }
        public override bool CanRead
        {
            get
            {
                return this.BaseStream.CanRead;
            }
        }
        public override bool CanSeek
        {
            get
            {
                return this.BaseStream.CanSeek;
            }
        }
        public override bool CanWrite
        {
            get
            {
                return this.BaseStream.CanWrite;
            }
        }
        public override void Flush()
        {
            this.BaseStream.Flush();
        }
        public override long Length
        {
            get
            {
                return this.BaseStream.Length;
            }
        }
        public override long Position
        {
            get
            {
                return this.BaseStream.Position;
            }
            set
            {
                this.BaseStream.Position = value;
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int returnValue = BaseStream.Read(buffer, offset, count);
            this.otherStream.Write(buffer, offset, returnValue);
            return returnValue;
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            try
            {
                this.OtherStream.Seek(offset, origin);
            }
            catch { }
            return BaseStream.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            try
            {
                this.OtherStream.SetLength(value);
            }
            catch { }
            this.BaseStream.SetLength(value);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            try
            {
                this.OtherStream.Write(buffer, offset, count);
            }
            catch { }
            this.BaseStream.Write(buffer, offset, count);
        }
    }
