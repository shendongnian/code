    public class Things {
        [XmlElement(DataType = typeof(string)),
        XmlElement(DataType = typeof(int))]
        public object[] StringsAndInts;
     }
