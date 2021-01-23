    private static readonly Random Random = new Random();
    public static string GenerateIdentifier()
    {
        var seconds = (int) DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        var timeBytes = BitConverter.GetBytes(seconds);
        var randomBytes = new byte[2];
        Random.NextBytes(randomBytes);
        var bytes = new byte[timeBytes.Length + randomBytes.Length];
        System.Buffer.BlockCopy(timeBytes, 0, bytes, 0, timeBytes.Length);
        System.Buffer.BlockCopy(randomBytes, 0, bytes, timeBytes.Length, randomBytes.Length);
        return Ascii85.Encode(bytes);
    }
