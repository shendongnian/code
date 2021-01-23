    public class Value : ISerializable 
    {
        public String Value { get; set; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
        }
    }
