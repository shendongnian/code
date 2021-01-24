    [JsonObject(MemberSerialization.OptIn)]
    public class BatchList : IBatchList
    {
        [JsonProperty(PropertyName = "Items", Required = Required.Always)]
        [JsonConverter(typeof(SingleOrArrayListItemConverter<IBatchItems>), typeof(ConcreteConverter<IBatchItems, BatchItems>))]
        public List<IBatchItems> Items { get; set; }
    }
