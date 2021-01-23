    [Serializable]
    [XmlInclude(typeof(c))]
    public class b
    {
        [XmlElement]
        public int prop1;
        [XmlElement]
        public string prop2;
    
        public b()
        {
            prop1 = 0;
            prop2 = String.Empty;
        }
    }
