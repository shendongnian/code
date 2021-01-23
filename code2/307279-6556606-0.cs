    public class ResponseContext
    {
        private List<ChannelContext> m_Channels;
        public ResponseContext()
        {
            m_Channels = new List<ChannelContext>();
        }
        public HeaderContext Header { get; set; }
        [JsonConverter(
            typeof(AssociativeArraysConverter<ChannelContextFieldNameResolver>))]
        public List<ChannelContext> Channels
        {
            get { return m_Channels; }
        }
    }
    [JsonObject(MemberSerialization = MemberSerialization.OptOut)]
    public class ChannelContext : IDataContext
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public string NominalId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
