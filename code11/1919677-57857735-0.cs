    var hashAlgorithm = new Org.BouncyCastle.Crypto.Digests.Sha3Digest(512);
    // Choose correct encoding based on your usecase
    byte[] input = Encoding.ASCII.GetBytes("test");
    hashAlgorithm.BlockUpdate(input, 0, input.Length);
    byte[] result = new byte[64]; // 512 / 8 = 64
    hashAlgorithm.DoFinal(result, 0);
    string hashString = BitConverter.ToString(result);
    hashString = hashString.Replace("-", "").ToLowerInvariant();
    Console.WriteLine(hashString);
