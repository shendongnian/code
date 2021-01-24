    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        while (true)
        {
            Console.WriteLine("Enter a 9 digit+ number to calculate hash");
            var val = Console.ReadLine();
            long target = 0;
            bool result = long.TryParse(val,out target);
            if (result)
            {
                var calculatedHash = OutputHash(target);
                Console.WriteLine("Calculated hash is : " + calculatedHash);
            }
            else
            {
                Console.WriteLine("Incorrect input. Please try again.");
            }
        }
    }
    public static string OutputHash(long number)
    {
        string source = Convert.ToString(number);
        string hash;
        using (SHA256 sha256Hash = SHA256.Create())
        {
            hash = GetHash(sha256Hash, source);
            Console.WriteLine($"The SHA256 hash of {source} is: {hash}.");
            Console.WriteLine("Verifying the hash...");
            if (VerifyHash(sha256Hash, source, hash))
            {
                Console.WriteLine("The hashes are the same.");
            }
            else
            {
                Console.WriteLine("The hashes are not same.");
            }
        }
        return hash;
    }
    private static string GetHash(HashAlgorithm hashAlgorithm, string input)
    {
        // Convert the input string to a byte array and compute the hash.
        byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        var sBuilder = new StringBuilder();
        // Loop through each byte of the hashed data 
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        // Return the hexadecimal string.
        return sBuilder.ToString();
    }
    // Verify a hash against a string.
    private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
    {
        // Hash the input.
        var hashOfInput = GetHash(hashAlgorithm, input);
        // Create a StringComparer an compare the hashes.
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;
        return comparer.Compare(hashOfInput, hash) == 0;
    }
