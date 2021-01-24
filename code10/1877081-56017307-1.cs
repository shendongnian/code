    public class MyModel
    {
        [ModelBinder(Name = "id")]
        [CustomStringLength(36, MinimumLength = 3)]
        public string ObjectId { get; set; }
    }
