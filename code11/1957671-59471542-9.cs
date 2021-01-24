    public class Model
    {
        [JsonConverter(typeof(OnlyBoolean))]
        public bool? Value {get; set;}
    }
