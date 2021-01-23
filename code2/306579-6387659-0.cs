    [Serializable]
    public class Car : IDeserializationCallback
    {
        public string model;
        public int year;
        public string colour;
        void IDeserializationCallback.OnDeserialization(object sender)
        {
            if (colour == null) colour = "";
        }
    }
