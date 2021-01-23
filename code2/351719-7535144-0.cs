        [XmlRoot("Plan")]
        public class EPlan
        {
            [XmlElement("Error")]
            public string Error { get; set; }
            [XmlElement("Description")]
            public string Description { get; set; }
            [XmlElement("Document")]
            public List<EDocument> Documents { get; set; }
        }
        [XmlType]
        public class EDocument
        {
            private string document;
            [XmlAnyElement]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public XmlElement[] DocumentNodes { get; set; }
            [XmlIgnore]
            public string Document
            {
                get
                {
                    if (this.document == null)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var node in this.DocumentNodes)
                        {
                            sb.Append(node.OuterXml);
                        }
                        this.document = sb.ToString();
                    }
                    return this.document;
                }
            }
        }
        static void Test()
        {
            string xml = @"<Plan>
      <Error>0</Error>
      <Description>1</Description>
      <Document>
        <ObjectID>06098INF1761320</ObjectID>
        <ced>109340336</ced>
        <abstract>DAVID STEVENSON</abstract>
        <ced_a />
        <NAM_REC />
        <ced_ap2 />
      </Document>
      <Document>
        <ObjectID>id2</ObjectID>
        <ced>ced2</ced>
        <abstract>abstract2</abstract>
        <ced_a />
        <NAM_REC />
        <ced_ap2 />
      </Document>
    </Plan>";
            XmlSerializer xs = new XmlSerializer(typeof(EPlan));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            EPlan obj = xs.Deserialize(ms) as EPlan;
            Console.WriteLine(obj.Documents[0].Document);
        }
