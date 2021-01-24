    const string lookup = "abcdefghijklmnop";
    public string Decode(string input)
    {
        byte[] buf = Convert.FromBase64String(input);
		var result = new StringBuilder(buf.Length*2);
		foreach (byte b in buf)
		{
			result.Append(lookup[b >> 4]).Append(lookup[b & 0xf]);
		}
		return result.ToString();
    }
    string h = Decode("XFEWtnopccImhpHTzGeoeXBg4ws=");
    System.Diagnostics.Debug.Assert(h == "fmfbbglghkcjhbmccgigjbndmmghkihjhagaodal");
