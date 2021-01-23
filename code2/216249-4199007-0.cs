    public string HexIt(string yourString)
    {
        string hex = "";
        foreach (char c in yourString)
        {
            int tmp = c;
            hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
        }
        return hex;
    }
