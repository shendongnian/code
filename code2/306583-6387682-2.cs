    [Serializable()]
    public class Car
    {
        public string colour;
        public string model;
        public int year;
        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
           if (colour == null)
           {
               colour = string.Empty;
           }
        }
    }
