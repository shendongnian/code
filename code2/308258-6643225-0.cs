    public class MyModelObject
    {
        [Required(ErrorMessage = "Foo")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
    public class MyModel
    {
        public MyModelObject MyObject { get; set; }
    }
