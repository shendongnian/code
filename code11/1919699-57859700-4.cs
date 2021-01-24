    public class ConfigContractResolver : DefaultContractResolver {
        private static readonly string[] source1Names = new[] { 
            nameof(Config.Property1),
            nameof(Config.Property2)
        };
        public bool ForSource1 { get; set; } = true;
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization) {
            var ret = base.CreateProperties(type, memberSerialization);
            var predicate = ForSource1 ? 
                x => source1Names.Contains(x.PropertyName) :
                (Func<JsonProperty, bool>)(x => !source1Names.Contains(x.PropertyName));
            ret = ret.Where(predicate).ToList();
            return ret;
        }
    }
