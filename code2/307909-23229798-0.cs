    public class KeyValuePairJsonConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> deserializedJSObjectDictionary, Type targetType, JavaScriptSerializer javaScriptSerializer)
        {
            Object targetTypeInstance = Activator.CreateInstance(targetType);
            FieldInfo[] targetTypeFields = targetType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo fieldInfo in targetTypeFields)
                fieldInfo.SetValue(targetTypeInstance, deserializedJSObjectDictionary[fieldInfo.Name]);
            return targetTypeInstance;
        }
        public override IDictionary<string, object> Serialize(Object objectToSerialize, JavaScriptSerializer javaScriptSerializer)
        {
           IDictionary<string, object> serializedObjectDictionary = new Dictionary<string, object>();
           FieldInfo[] objectToSerializeTypeFields = objectToSerialize.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
           foreach (FieldInfo fieldInfo in objectToSerializeTypeFields)
               serializedObjectDictionary.Add(fieldInfo.Name, fieldInfo.GetValue(objectToSerialize));
           return serializedObjectDictionary;
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                return new ReadOnlyCollection<Type>(new Type[] { typeof(YOURCLASSNAME) });
            }
        }
    }
