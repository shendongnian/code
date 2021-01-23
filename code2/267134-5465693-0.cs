        public class ModifyResponseExtension : SoapExtension
        {
            Stream inStream;
            Stream outStream;
            // Save the Stream representing the SOAP request or SOAP response into
            // a local memory buffer.
            public override Stream ChainStream(Stream stream)
            {
                inStream = stream;
                outStream = new MemoryStream();
                return outStream;
            }
            //This can get properties out of the Attribute used to enable this
            public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
            {
                return null;
            }
            //This would have default settings when enabled by config file
            public override object GetInitializer(Type WebServiceType)
            {
                return null;
            }
            // Receive the object returned by GetInitializer-- set any options here
            public override void Initialize(object initializer)
            {
            }
            //  If the SoapMessageStage is such that the SoapRequest or
            //  SoapResponse is still in the SOAP format to be sent or received,
            //  save it out to a file.
            public override void ProcessMessage(SoapMessage message)
            {
                switch (message.Stage)
                {
                    case SoapMessageStage.BeforeSerialize:
                        break;
                    case SoapMessageStage.AfterSerialize:
                        //This is after the Request has been serialized, I don't need to modify this so just copy the stream as-is
                        outStream.Position = 0;
                        Copy(outStream, inStream);
                        //Not sure if this is needed (MSDN does not have it) but I like closing things
                        outStream.Close();
                        inStream.Close();
                        break;
                    case SoapMessageStage.BeforeDeserialize:
                        //This is before the Response has been deserialized, modify here
                        //Could also modify based on something in the SoapMessage object if needed
                        ModifyResponseMessage();
                        break;
                    case SoapMessageStage.AfterDeserialize:
                        break;
                }
            }
            private void ModifyResponseMessage()
            {
                TextReader reader = new StreamReader(inStream);
                TextWriter writer = new StreamWriter(outStream);
                //Using a StringBuilder for the replacements here
                StringBuilder sb = new StringBuilder(reader.ReadToEnd());
                //Modify the stream so it will deserialize with the current version (downgrading to Version1_1 here)
                sb.Replace("SummaryData_Version2_2Impl", "SummaryData_Version1_1Impl")
                    .Replace("SummaryData_Version3_3Impl", "SummaryData_Version1_1Impl")
                    .Replace("SummaryData_Version4_4Impl", "SummaryData_Version1_1Impl");
                //Replace the namespace
                sb.Replace("http://version2_2", "http://version1_1")
                    .Replace("http://version3_3", "http://version1_1")
                    .Replace("http://version4_4", "http://version1_1");
                //Note: Can output to a log message here if needed, with sb.ToString() to check what is different between the version responses
                writer.WriteLine(sb.ToString());
                writer.Flush();
                //Not sure if this is needed (MSDN does not have it) but I like closing things
                inStream.Close();
                outStream.Position = 0;
            }
            void Copy(Stream from, Stream to)
            {
                TextReader reader = new StreamReader(from);
                TextWriter writer = new StreamWriter(to);
                writer.WriteLine(reader.ReadToEnd());
                writer.Flush();
            }
        }
        // Create a SoapExtensionAttribute for the SOAP Extension that can be
        // applied to an XML Web service method.
        [AttributeUsage(AttributeTargets.Method)]
        public class ModifyResponseExtensionAttribute : SoapExtensionAttribute
        {
            private int priority;
            public override Type ExtensionType
            {
                get { return typeof(ModifyResponseExtension); }
            }
            public override int Priority
            {
                get { return priority; }
                set { priority = value; }
            }
        }
