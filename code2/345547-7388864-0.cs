    public class StackOverflow_7386673
    {
        [DataContract(Name = "job", Namespace = "")]
        public class Job
        {
            [DataMember(Order = 0)]
            public string refno { get; set; }
            [DataMember(Order = 1)]
            public SpecialismList specialisms { get; set; }
        }
        [CollectionDataContract(Name = "specialisms", ItemName = "specialism", Namespace = "")]
        public class SpecialismList : List<int> { }
        public static void Test()
        {
            MemoryStream ms = new MemoryStream();
            DataContractSerializer dcs = new DataContractSerializer(typeof(Job));
            Job job = new Job
            {
                refno = "XXX",
                specialisms = new SpecialismList { 1, 2 }
            };
            XmlWriterSettings ws = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true,
                IndentChars = "  ",
                Encoding = new UTF8Encoding(false),
            };
            XmlWriter w = XmlWriter.Create(ms, ws);
            dcs.WriteObject(w, job);
            w.Flush();
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }
    }
