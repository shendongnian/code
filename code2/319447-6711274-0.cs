    public class Page:AbstractElementModel
    {
        [XmlElement("Group", typeof(Group))]
        [XmlElement("Text", typeof(Text))]
        public AbstractElementModel[] content;
    }
