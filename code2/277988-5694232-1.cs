    public class NameAttribute : RegularExpressionAttribute
    {
        public NameAttribute() : base("abc*") { }
    }
    public class MyViewModel
    {
        [Name(ErrorMessage = "asdasd")]
        public string LastName { get; set; }
    }
