    [Rule(Code = "0045", ErrorMessage = "foo bar", Order = 1)]
    public class IsValidColor : IisValid
    {
        public bool IsValid(Foo bar)
        {
            // validation rules here
        }
    }
