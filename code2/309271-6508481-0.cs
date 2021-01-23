    [Serializable]
    public class ProxyAnonymousObject : ISerializable {
        static Dictionary<string, Type> cached = new Dictionary<string, Type>();
        object model;
        public Dictionary<string, object> ModelProperties = new Dictionary<string, object>();
        public ProxyAnonymousObject(object model) { this.model = model; }
        public ProxyAnonymousObject(SerializationInfo info, StreamingContext ctx) {
            try {
                string fieldName = string.Empty;
                object fieldValue = null;
                foreach (var field in info) {
                    fieldName = field.Name;
                    fieldValue = field.Value;
                    if (string.IsNullOrWhiteSpace(fieldName))
                        continue;
                    if (fieldValue == null)
                        continue;
                    ModelProperties.Add(fieldName, fieldValue);
                }
            } catch (Exception e) {
                var x = e;
            }
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            foreach (var pi in model.GetType().GetProperties()) {
                info.AddValue(pi.Name, pi.GetValue(model, null), pi.PropertyType);
            }
        }
    }
    public class ProxyDynamicObject : DynamicObject{
        internal ProxyAnonymousObject Proxy { get; set; }
        
        public ProxyDynamicObject(ProxyAnonymousObject model) {
            this.Proxy = model;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            result = Proxy.ModelProperties[binder.Name];
            return true;
        }
    }
