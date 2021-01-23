    public class Dependency : IJsonSerializable
    {
        public object Key { get; set; } // recordKey
        public LinkType Type { get; set; } // SP.JsGrid.LinkType
        public Dependency() {
            Key = DBNull.Value;
            Type = LinkType.FinishStart;
        }
        public string ToJson(Serializer s)
        {
            return JsonUtility.SerializeToJsonFromProperties(s, this);
        }
    }
