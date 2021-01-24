    public class SerializationHooksExamples
    {
        /// Will be executed when deserializing starts
        [OnDeserializing]
        protected void OnDeserializing(StreamingContext ctx)
        {
            //...
        }
        /// Will be executed when deserializing finished
        [OnDeserialized]
        protected void OnDeserialized(StreamingContext ctx)
        {
            //...
        }
        /// Will be executed when serializing starts
        [OnSerializing]
        protected void OnSerializing(StreamingContext ctx)
        {
            //...
        }
        /// Will be executed when serializing finished
        [OnSerialized]
        protected void OnSerialized(StreamingContext ctx)
        {
            //...
        }
    }
