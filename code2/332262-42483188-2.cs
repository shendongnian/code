    public static string generate_Digits(int length)
    {
        var rndDigits = new System.Text.StringBuilder().Insert(0, "0123456789", length).ToString().ToCharArray();
        return string.Join("", rndDigits.OrderBy(o => Guid.NewGuid()).Take(length));
    }
