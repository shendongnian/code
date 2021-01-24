    public class Model
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string SecretKey { get; set; } // "hidden" from the client
    }
    public class ClientModel
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }
