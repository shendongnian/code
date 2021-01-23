        class SoapExt : SoapExtension
        {
            private Stream mWireStream = null;
            private Stream mApplicationStream = null;
            public override object GetInitializer(Type serviceType)
            {
                return serviceType;
            }
            public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
            {
                return (SoapExtAttribute)attr;
            }
            public override void Initialize(object initializer)
            {
            }
            public override Stream ChainStream(Stream stream)
            {
                mWireStream = stream;
                mApplicationStream = new MemoryStream();
                return mApplicationStream;
            }
            public override void ProcessMessage(SoapMessage message)
            {
                StreamWriter writer = null;
                bool fIsServer = (message.GetType() == typeof(SoapServerMessage));
                switch (message.Stage)
                {
                    case SoapMessageStage.BeforeDeserialize:
                        string resp = new StreamReader(mWireStream).ReadToEnd();
                        StreamWriter w = new StreamWriter(mApplicationStream);
                        w.WriteLine(resp);
                        w.Flush();
                        mApplicationStream.Seek(0, SeekOrigin.Begin);
                        break;
                    case SoapMessageStage.AfterSerialize:
                        mApplicationStream.Seek(0, SeekOrigin.Begin);
                        string reqXml = new StreamReader(mApplicationStream).ReadToEnd();
                        
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(reqXml);
                        Modify(doc);
                        reqXml = doc.InnerXml;
                        
                        mApplicationStream.Seek(0, SeekOrigin.Begin);
                        writer = new StreamWriter(mWireStream);
                        writer.WriteLine(reqXml);
                        writer.Flush();
                        XmlDocument d = new XmlDocument();
                        d.LoadXml(reqXml);
                        ServiceManager.RequestSoap = d.LastChild.OuterXml;
                        break;
                }
            }
            private void Modify(XmlDocument doc)
            {
                // Change the doc in whatever way you want, e.g. remove/add the prefixes
            }
        }
