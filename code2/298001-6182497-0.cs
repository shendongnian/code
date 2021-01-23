    string hex = "0123456789abcdef";
    string input = "0x45";
    Debug.Assert(Regex.Match(input, "^0x[0-9a-f]{2}$").Success);
    byte[] result = new byte[2];
    result[0] = hex.IndexOf(input[2]);
    result[1] = hex.IndexOf(input[3]);
