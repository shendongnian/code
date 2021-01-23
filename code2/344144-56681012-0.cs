    public static string GetOAuth_1_TwoLeggedHeaderString(string url, string httpMethod
        , string consumerKey, string consumerSecret)
    {
        var timeStamp = ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
        var nonce = Guid.NewGuid().ToString("D");
        var signatureMethod = "HMAC-SHA1";
        var version = "1.0";
        var signatureBase = Encode(httpMethod.ToUpper()) + "&";
        signatureBase += Encode(url.ToLower()) + "&";
        signatureBase += Encode("oauth_consumer_key=" + Encode(consumerKey) + "&" +
            "oauth_nonce=" + Encode(nonce) + "&" +
            "oauth_signature_method=" + Encode(signatureMethod) + "&" +
            "oauth_timestamp=" + Encode(timeStamp) + "&" +
            "oauth_version=" + Encode(version));
        string signatureString;
        using (HMACSHA1 crypto = new HMACSHA1())
        {
            string key = Encode(consumerSecret) + "&";
            crypto.Key = Encoding.ASCII.GetBytes(key);
            string hash = Convert.ToBase64String(crypto.ComputeHash(Encoding.ASCII.GetBytes(signatureBase)));
            crypto.Clear();
            signatureString = hash;
        }
        string SimpleQuote(string s) => '"' + s + '"';
        return
            "OAuth " +
            "oauth_consumer_key=" + SimpleQuote(Encode(consumerKey)) + ", " +
            "oauth_signature_method=" + SimpleQuote(Encode(signatureMethod)) + ", " +
            "oauth_timestamp=" + SimpleQuote(Encode(timeStamp)) + ", " +
            "oauth_nonce=" + SimpleQuote(Encode(nonce)) + ", " +
            "oauth_version=" + SimpleQuote(Encode(version)) + ", " +
            "oauth_signature=" + SimpleQuote(Encode(signatureString));
    }
    private static string Encode(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;
        return Encoding.ASCII.GetString(EncodeToBytes(input, Encoding.UTF8));
    }
    private static byte[] EncodeToBytes(string input, Encoding enc)
    {
        if (string.IsNullOrEmpty(input))
            return new byte[0];
        byte[] inbytes = enc.GetBytes(input);
        // Count unsafe characters
        int unsafeChars = 0;
        char c;
        foreach (byte b in inbytes)
        {
            c = (char)b;
            if (NeedsEscaping(c))
                unsafeChars++;
        }
        // Check if we need to do any encoding
        if (unsafeChars == 0)
            return inbytes;
        byte[] outbytes = new byte[inbytes.Length + (unsafeChars * 2)];
        int pos = 0;
        for (int i = 0; i < inbytes.Length; i++)
        {
            byte b = inbytes[i];
            if (NeedsEscaping((char)b))
            {
                outbytes[pos++] = (byte)'%';
                outbytes[pos++] = (byte)IntToHex((b >> 4) & 0xf);
                outbytes[pos++] = (byte)IntToHex(b & 0x0f);
            }
            else
                outbytes[pos++] = b;
        }
        return outbytes;
    }
    private static bool NeedsEscaping(char c)
    {
        return !((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9')
                || c == '-' || c == '_' || c == '.' || c == '~');
    }
    private static char IntToHex(int n)
    {
        if (n < 0 || n >= 16)
            throw new ArgumentOutOfRangeException("n");
        if (n <= 9)
            return (char)(n + (int)'0');
        else
            return (char)(n - 10 + (int)'A');
    }
