private byte[] ComputePasswordHash(string password, int salt)
{
    byte[] saltBytes = new byte[4];
    saltBytes[0] = (byte)(salt >> 24);
    saltBytes[1] = (byte)(salt >> 16);
    saltBytes[2] = (byte)(salt >> 8);
    saltBytes[3] = (byte)(salt);
    byte[] passwordBytes = UTF8Encoding.UTF8.GetBytes(password);
    byte[] preHashed = new byte[saltBytes.Length + passwordBytes.Length];
    System.Buffer.BlockCopy(passwordBytes, 0, preHashed, 0, passwordBytes.Length);
    System.Buffer.BlockCopy(saltBytes, 0, preHashed, passwordBytes.Length, saltBytes.Length);
    SHA1 sha1 = SHA1.Create();
    return sha1.ComputeHash(preHashed);
}
