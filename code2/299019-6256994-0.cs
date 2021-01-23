    public class DynamicSettings : DynamicObject {
        public DynamicSettings(NameValueCollection settings) {
            items = settings;
        }
        private readonly NameValueCollection items;
        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            result = items.Get(binder.Name);
            return result != null;
        }
    }
