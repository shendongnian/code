    using System.IO;
    using System.Xml;
    using System.Xml.Schema;
    public void LoadXml(string path) {
        XmlDocument doc = new XmlDocument();
        XmlReader docReader;
        
        XmlReaderSettings rdrOpts = new XmlReaderSettings();
        rdrOpts.ValidationType = ValidationType.Schema;
        rdrOpts.ValidationFlags = XmlSchemaValidationFlags.ProcessSchemaLocation;
        
        try {
            // This line is what you're looking for:
            docReader = XmlReader.Create(new FileStream(path, FileMode.Open, FileAccess.Read), rdrOpts, Path.GetDirectoryName(path));
            doc.Load(docReader);
        } catch (System.Xml.Schema.XmlSchemaValidationException ex) {
            //...
        } //and catch any other relevant exceptions here, like System.IO.FileNotFoundException
    }
