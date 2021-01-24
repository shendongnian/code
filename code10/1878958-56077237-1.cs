    QTMCollection collection = new ConsoleApplication135.QTMCollection()
    {
        QTMs = new List<QTM>
        {
            new QTM() { SampleId = 1, IW = 0.0889M, SL = 24.24M, PO = 117 },
            new QTM() { SampleId = 2, IW = 0.896M, SL = 24.41M, PO = 119 },
            new QTM() { SampleId = 3, IW = 0.922M, SL = 24.3M, PO = 125 },
            new QTM() { SampleId = 4, IW = 0.94M, SL = 24.24M, PO = 129 },
            new QTM() { SampleId = 5, IW = 0.987M, SL = 24.32M, PO = 127 }
        }
    };            
                
    using (FileStream fileStream = new FileStream(@"c:\temp\B.xml", FileMode.Create))
    {                
        using (var writer = XmlWriter.Create(fileStream, new XmlWriterSettings() { OmitXmlDeclaration = true, Indent = true }))
        {
            var serializer = new XmlSerializer(typeof(QTMCollection));
            serializer.Serialize(writer, collection, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
        }
    }
