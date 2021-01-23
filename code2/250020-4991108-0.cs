    byte[] buffer = new byte[16 * 1024];
    int bytesToWrite = 719585280;
    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
    using (Stream output = File.Create("crypto.bin"))
    {
        while (bytesToWrite > 0)
        {
            rng.GetBytes(buffer);
            int bytesThisTime = Math.Min(bytesToWrite, buffer.Length);
            output.Write(buffer, 0, bytesThisTime);
            bytesToWrite -= bytesThisTime;
        }
    }
