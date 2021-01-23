    public class ExpandoConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        { return DictionaryToExpando(dictionary); }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        { return ((ExpandoObject)obj).ToDictionary(x => x.Key, x => x.Value); }
        public override IEnumerable<Type> SupportedTypes
        { get { return new ReadOnlyCollection<Type>(new Type[] { typeof(System.Dynamic.ExpandoObject) }); } }
        private ExpandoObject DictionaryToExpando(IDictionary<string, object> source)
        {
            var expandoObject = new ExpandoObject();
            var expandoDictionary = (IDictionary<string, object>)expandoObject;
            foreach (var kvp in source)
            {
                if (kvp.Value is IDictionary<string, object>) expandoDictionary.Add(kvp.Key, DictionaryToExpando((IDictionary<string, object>)kvp.Value));
                else if (kvp.Value is ICollection)
                {
                    var valueList = new List<object>();
                    foreach (var value in (ICollection)kvp.Value)
                    {
                        if (value is IDictionary<string, object>) valueList.Add(DictionaryToExpando((IDictionary<string, object>)value));
                        else valueList.Add(value);
                    }
                    expandoDictionary.Add(kvp.Key, valueList);
                }
                else expandoDictionary.Add(kvp.Key, kvp.Value);
            }
            return expandoObject;
        }
    }
