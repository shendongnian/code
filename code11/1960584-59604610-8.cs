    public class Model
    {
        [JsonConverter(typeof(StackConverter<int>))]
        public Stack<int> Stack { get; set; }
    }
