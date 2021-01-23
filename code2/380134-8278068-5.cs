    public static class Maybe
    {
        public static Maybe<T> NotNull<T>(T value) where T : class
        {
            return value != null ? Maybe<T>.Just(value) : Maybe<T>.Nothing;
        }
        public static Maybe<string> NotEmpty(string value)
        {
            return value.Length != 0 ? Maybe<string>.Just(value) : Maybe<string>.Nothing;
        }
    }
    string foo = "whatever";
    Maybe.NotNull(foo).Bind(x => Maybe.NotEmpty(x)).Bind(x => { Console.WriteLine(x); return Maybe<string>.Just(x); });
