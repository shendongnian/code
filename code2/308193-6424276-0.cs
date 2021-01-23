    [DataContract]
    class MyClass
    {
        [DataMember(Order = 1)]
        private MyCompoundClass _someCompoundField;
    
        [DataMember(Order = 2)]
        private int _someOtherField;
    
        private void SaveState()
        {
            using (Stream stream = GetStream())
            {
                ProtoBuf.Serializer.Serialize(stream, this);
            }
        }
    
        private void LoadState()
        {
            using (Stream stream = GetStream())
            {
                ProtoBuf.Serializer.Merge(stream, this);
            }
        }
    }
