    string magic(string encodedOrNot)
    {
        var decoded = HttpUtility.HtmlDecode(encodedOrNot);
        return HttpUtility.HtmlEncode(decoded);
    }
