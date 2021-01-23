    [XmlType(TypeName="Data")]
    public class BaseAttributeHolder
    {
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlText]
        public string Value { get; set; }
        public BaseAttributeHolder(string value, string id, string type = "extra")
        {
            Type = type;
            Value = value;
            Id = id;
        }
        public BaseAttributeHolder(string id, string type = "extra")
        {
            Type = type;
            Id = id;
        }
        public BaseAttributeHolder(string type = "extra")
        {
            Type = type;
        }
        public BaseAttributeHolder()
        {
        }
    }
    [XmlRoot("DataSet")]
    public class AddListCallHolder
    {
        private BaseAttributeHolder _name = new BaseAttributeHolder(type: "");
        public List<BaseAttributeHolder> Attributes { get; set; }
        public AddListCallHolder()
        {
            Attributes = new List<BaseAttributeHolder>();
            Attributes.Add(new BaseAttributeHolder(id: "CLICKTHRU_URL"));
            Attributes.Add(new BaseAttributeHolder());
        }
    }
