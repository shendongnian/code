    string crypto(string input, bool encrypt)
    {
        Random rnd = new Random(123);
        StringBuilder sb = new StringBuilder();
        int sgn = encrypt ? 1 : -1;
        for (int i = 0; i < input.Length; i++)
        {
            sb.Append( ((char) ( (byte)input[i] + sgn * rnd.Next(63))) .ToString());
        }
        return sb.ToString();
    }
