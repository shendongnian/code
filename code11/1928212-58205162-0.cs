    public class SomeClass2 : DynamicObject, ISomeInterface
    {
        private Dictionary<string, object> dictionary = new Dictionary<string, object>();
        [JsonProperty]
        public string InterfaceMember { get; set; }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return dictionary.TryGetValue(binder.Name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;
            return true;
        }
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return dictionary.Keys;
        }
    }
