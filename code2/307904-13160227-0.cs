        public class KeyValuePairJsonConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            var instance = Activator.CreateInstance(type);
            foreach (var p in instance.GetType().GetPublicProperties())
            {
                instance.GetType().GetProperty(p.Name).SetValue(instance, dictionary[p.Name], null);
                dictionary.Remove(p.Name);
            }
            foreach (var item in dictionary)
                (instance).Add(item.Key, item.Value);
            return instance;
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            var result = new Dictionary<string, object>();
            var dictionary = obj as IDictionary<string, object>;
            foreach (var item in dictionary)
                result.Add(item.Key, item.Value);
            return result;
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                return new ReadOnlyCollection<Type>(new Type[] { typeof(your_type) });
            }
        }
    }
    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
    javaScriptSerializer.RegisterConverters(new JavaScriptConverter[] { new ExpandoJsonConverter() });
    jsonOfTest = javaScriptSerializer.Serialize(test);
    // {"x":"xvalue","y":"\/Date(1314108923000)\/"}
