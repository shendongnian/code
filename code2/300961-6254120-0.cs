    public IEnumerable<byte> GetBytesFromByteString(string s) {
        for (int index = 0; index < s.Length; index += 2) {
            yield return Convert.ToByte(s.Substring(index, 2), 16);
        }
    }
