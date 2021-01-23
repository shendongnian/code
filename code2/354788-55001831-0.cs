    [DataContract]
    public class Message
    {
        [DataMember] private List<string> Types = new List<string>();
        [DataMember] private Dictionary<string, object> Data = new Dictionary<string, object>();
        public object this[string id]
        {
            get => Data.TryGetValue(id, out var o) ? o : null;
            set {
                Data[id] = value;
                if (!Types.Contains(value.GetType().AssemblyQualifiedName))
                    Types.Add(value.GetType().AssemblyQualifiedName);
            }
        }
        public byte[] Serialize()
        {
            var dcs = new DataContractSerializer(typeof(Message), Types.Select(Type.GetType));
            using (var ms = new MemoryStream()) {
                dcs.WriteObject(ms, this);
                return ms.ToArray();
            }
        }
        public static Message Deserialize(byte[] input)
        {
            var types = new List<string>();
            using (var xr = XmlReader.Create(new StringReader(Encoding.UTF8.GetString(input)))) {
                if (xr.ReadToFollowing(nameof(Types))) {
                    xr.ReadStartElement();
                    while (xr.NodeType != XmlNodeType.EndElement) {
                        var res = xr.ReadElementContentAsString();
                        if (!string.IsNullOrWhiteSpace(res))
                            types.Add(res);
                    }
                }
            }
            var dcs = new DataContractSerializer(typeof(Message), types.Select(Type.GetType));
            using (var ms = new MemoryStream(input))
                if (dcs.ReadObject(ms) is Message msg)
                    return msg;
            return null;
        }
    }
