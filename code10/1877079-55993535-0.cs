    public class MyModel
    {
        [ModelBinder(Name = "id")]
        [StringLength(36, MinimumLength = 3, ErrorMessage="The field id must be a string with a minimum length of {1} and a maximum length of {2}.")]
        public string ObjectId { get; set; }
    }
