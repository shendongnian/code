    string magic(string encodedOrNot)
    {
        var decoded = HtmlUtility.HtmlDecode(encodedOrNot);
        return HtmlUtility.HtmlEncode(decoded);
    }
