    string Unhash(uint result)
    {
        StringBuilder sb = new StringBuilder();
        while (result != 0)
        {
            sb.Append((char)(result & 0x1f));
            result >>= 5;
        }
        string s = new string(((IEnumerable<char>)sb.ToString()).Reverse().ToArray());
        return s;
    }
