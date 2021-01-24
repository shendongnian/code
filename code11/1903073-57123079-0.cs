    static char[] alphaU = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    static char[] alphaL = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    static char[] number = "0123456789".ToCharArray();
    static Random random = new Random();
    static StringBuilder sb = new StringBuilder(100);
    private static string GenerateRandomAlphanumericValue(string input)
    {
        sb.Clear();
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsNumber(input[i]))
            {
                int index = random.Next(0, number.Length);
                sb.Append(number[index]);
            }
            else if (char.IsUpper(input[i]))
            {
                int index = random.Next(0, alphaU.Length);
                sb.Append(alphaU[index]);
            }
            else if (char.IsLower(input[i]))
            {
                int index = random.Next(0, alphaL.Length);
                sb.Append(alphaL[index]);
            }
            else
            {
                sb.Append(input[i]);
            }
        }
        return sb.ToString();
    }
