    public class JsonClientSideObjectWriter : ClientSideObjectWriter
    {
        public JsonClientSideObjectWriter(string id, string type, TextWriter textWriter)
            : base(id, type, textWriter)
        {
        }
        public override IClientSideObjectWriter AppendObject(string name, object value)
        {
            Guard.IsNotNullOrEmpty(name, "name");
            var data = JsonConvert.SerializeObject(value,
                Formatting.None,
                new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new PropertyNameIgnoreContractResolver()
                    });
            return Append("{0}:{1}".FormatWith(name, data));
        }
        public override IClientSideObjectWriter AppendCollection(string name, System.Collections.IEnumerable value)
        {
            Guard.IsNotNullOrEmpty(name, "name");
            var data = JsonConvert.SerializeObject(value,
                Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new PropertyNameIgnoreContractResolver()
                });
            return this.Append(StringExtensions.FormatWith("{0}:{1}", (object)name, (object)data));
        }
    }
