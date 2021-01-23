    public void Xsd_whithout_saved()  
        {  
            XmlDocument xmlDoc = new XmlDocument();  
            xmlDoc.Load(@"file.xsd");  
            //In the futute, strArquivoInteiro will be fullfill by xsd comming from   database as nvarchar(max) and I will //not be allowed to save as a file locally    
            string strArquivoInteiro = xmlDoc.OuterXml;  
            byte[] byteArray = Encoding.ASCII.GetBytes(strArquivoInteiro);
            MemoryStream streamXSD = new MemoryStream(byteArray);
            //<<<
            streamXSD.Position = 0;
            StreamReader readerXsd = new StreamReader(streamXSD);
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationEventHandler += this.MyValidationEventHandler;
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(null, XmlReader.Create(readerXsd));
            settings.CheckCharacters = true;
            XmlReader XmlValidatingReader = XmlReader.Create(@"file.xml", settings);
            XmlTextReader Reader = new XmlTextReader(@"file.xsd");
            //Created another reader for xml to use for validation
            XmlTextReader Reader2 = new XmlTextReader(@"file.xml");
            XmlSchema Schema = new XmlSchema();
            //IN THIS LINE I RECEIVED THE XmlException "Root Element is Missing" and I can't understand the reason
            //This was the first problem, a xsd root element isn't equal to an xml root element , and you where trying to validate and xsd with xsd here, and of course the error.
            Schema = XmlSchema.Read(Reader, MyValidationEventHandler);
            XmlValidatingReader ValidatingReader = new XmlValidatingReader(Reader2);
            ValidatingReader.ValidationType = ValidationType.Schema;
            ValidatingReader.Schemas.Add(Schema);
            try
            {
                XmlValidatingReader.Read();
                XmlValidatingReader.Close();
                ValidatingReader.ValidationEventHandler += MyValidationEventHandler;
                while ((ValidatingReader.Read()))
                {
                }
                ValidatingReader.Close();
            }
            catch (Exception ex)
            {
                ValidatingReader.Close();
                XmlValidatingReader.Close();
            }
        }
