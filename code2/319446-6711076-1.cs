    [Serializable]
    public class Page:AbstractElementModel
    {
        [XmlArrayItem()]
        public Group[] Group;
        [XmlArrayItem()]
        public Text[] Text;
    }
