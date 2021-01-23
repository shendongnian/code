    public class Flexpando : DynamicObject {
        public Dictionary<string, object> Dictionary
            = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        public override bool TrySetMember(SetMemberBinder binder, object value) {
            Dictionary[binder.Name] = value;
            return true;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            return Dictionary.TryGetValue(binder.Name, out result);
        }
    }
