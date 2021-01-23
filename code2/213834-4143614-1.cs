    [XmlType]
    public class CT {
        [XmlElement(Order = 1)]
        public int Foo { get; set; }
    }
    [XmlType]
    public class TE {
        [XmlElement(Order = 1)]
        public int Bar { get; set; }
    }
    [XmlType]
    public class TD {
        [XmlElement(Order=1)]
        public List<CT> CTs { get; set; }
        [XmlElement(Order=2)]
        public List<TE> TEs { get; set; }
        [XmlElement(Order = 3)]
        public string Code { get; set; }
        [XmlElement(Order = 4)]
        public string Message { get; set; }
        [XmlElement(Order = 5)]
        public DateTime StartDate { get; set; }
        [XmlElement(Order = 6)]
        public DateTime EndDate { get; set; }
    
        public static byte[] Serialize(List<TD> tData) {
            using (var ms = new MemoryStream()) {
                ProtoBuf.Serializer.Serialize(ms, tData);
                return ms.ToArray();
            }            
        }
    
        public static List<TD> Deserialize(byte[] tData) {
            using (var ms = new MemoryStream(tData)) {
                return ProtoBuf.Serializer.Deserialize<List<TD>>(ms);
            }
        }
    }
