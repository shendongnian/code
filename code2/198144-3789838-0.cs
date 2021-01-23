    public static void Process(int i) { ... }
    public static void Process(string s) { ... }
    public static void Process(Dictionary<string, string> dic) { ... }
    public static void Process(Dictionary<string, int> dic) { ... }
    [...]
    public dynamic Decode(string input)     // or 'object' if you prefer
    {
        var t = GetDecodedType(input);
        if (t == typeof(int))
            return DecodeInt(input);
        else if (t == ...)
            // ...
    }
    [...]
    string s = ...; // Encoded string
    Process(Encoder.Decode(s));            // if you used 'dynamic' above
    Process((dynamic)Encoder.Decode(s));   // if you used 'object' above
