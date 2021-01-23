    string testString = "123";
    byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(testString);
    byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
    string hashedString = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
    // hashString == 202cb962ac59075b964b07152d234b70
