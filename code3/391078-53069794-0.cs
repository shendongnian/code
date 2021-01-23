    public abstract class StringEnumBase<T> : IEquatable<T>
        where T : StringEnumBase<T>
    {
        public string Value { get; }
        protected StringEnumBase(string value) => this.Value = value;
        public override string ToString() => this.Value;
        public static List<T> AsList()
        {
            return typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType == typeof(T))
                .Select(p => (T)p.GetValue(null))
                .ToList();
        }
        public static T Parse(string value)
        {
            List<T> all = AsList();
            if (!all.Any(a => a.Value == value))
                throw new InvalidOperationException($"\"{value}\" is not a valid value for the type {typeof(T).Name}");
            return all.Single(a => a.Value == value);
        }
        public bool Equals(T other)
        {
            if (other == null) return false;
            return this.Value == other?.Value;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is T other) return this.Equals(other);
            return false;
        }
        public override int GetHashCode() => this.Value.GetHashCode();
        public static bool operator ==(StringEnumBase<T> a, StringEnumBase<T> b) => a?.Equals(b) ?? false;
        public static bool operator !=(StringEnumBase<T> a, StringEnumBase<T> b) => !(a?.Equals(b) ?? false);
        public class JsonConverter<T> : Newtonsoft.Json.JsonConverter
            where T : StringEnumBase<T>
        {
            public override bool CanRead => true;
            public override bool CanWrite => true;
            public override bool CanConvert(Type objectType) => ImplementsGeneric(objectType, typeof(StringEnumBase<>));
            private static bool ImplementsGeneric(Type type, Type generic)
            {
                while (type != null)
                {
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == generic)
                        return true;
                    type = type.BaseType;
                }
                return false;
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JToken item = JToken.Load(reader);
                string value = item.Value<string>();
                return StringEnumBase<T>.Parse(value);
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (value is StringEnumBase<T> v)
                    JToken.FromObject(v.Value).WriteTo(writer);
            }
        }
    }
