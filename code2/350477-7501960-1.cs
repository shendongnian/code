    [Serializable]
    public class DynamicSerializable : DynamicObject,ISerializable
    {
        private readonly Dictionary<string, object> dictionary = new Dictionary<string, object>();
    
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (!dictionary.ContainsKey(binder.Name))
            {
                dictionary.Add(binder.Name, value);
            }
            else
            {
                dictionary[binder.Name] = value;
            }
    
            return true;
        }
    
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            foreach (var kvp in dictionary)
            {
                info.AddValue(kvp.Key, kvp.Value);
            }
        }
    }
    
    [KnownType(typeof(DynamicSerializable))]
    [DataContract]
    public class Root
    {
        [DataMember]
        public string Name { get; set; }
    
        [DataMember]
        public dynamic DynamicValues { get; set; }
    }
