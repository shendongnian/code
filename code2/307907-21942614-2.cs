    public class KeyValuePairJsonConverter : JavaScriptConverter {
        public override object Deserialize(IDictionary<string, object> dictionary
                                            , Type type
                                            , JavaScriptSerializer serializer) {
            throw new InvalidOperationException("Sorry, I do serializations only.");
        }
    
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer) {
            Dictionary<string, object> result = new Dictionary<string, object>();
            Dictionary<string, MyClass> dictionaryInput = obj as Dictionary<string, MyClass>;
    
            if (dictionaryInput == null) {
                throw new InvalidOperationException("Object must be of Dictionary<string, MyClass> type.");
            }
    
            foreach (KeyValuePair<string, MyClass> pair in dictionaryInput)
                result.Add(pair.Key, pair.Value);
    
            return result;
        }
    
        public override IEnumerable<Type> SupportedTypes {
            get {
                return new ReadOnlyCollection<Type>(new Type[] { typeof(Dictionary<string, MyClass>) });
            }
        }
    }
