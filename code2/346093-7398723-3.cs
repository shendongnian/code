    const string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
    public static string ToBase36(byte[] bytes) {
        StringBuilder sb = new StringBuilder();
        int i = 0;
        while (i < bytes.Length && bytes[i] == 0) {
            i++;
        }
        sb.Append(chars[0], i);
        var bi = new BigInteger(bytes.Skip(i).Reverse().Concat(new byte[] { 0 }).ToArray());
        while (bi > 0) {
            sb.Append(chars[(int)(bi % chars.Length)]);
            bi /= chars.Length;
        }
        return sb.ToString();
    }
