    static readonly Regex r = new Regex(@"^[0-9A-F\r\n]+$");
    public static bool VerifyHex(string _hex)
    {
        return r.Match(_hex).Success;
    }
