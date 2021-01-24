    public class TestModel
    {
        [RegularExpression(@"^((?!(https?:.*(?=\s))).)*$", ErrorMessage = "URL's are not allowed.")]
        public string Text { get; set; }
    }
