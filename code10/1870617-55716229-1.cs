    byte[] passwordBytes = GetBytes(password); // Where you have to define GetBytes
    byte[] saltBytes = System.Convert.FromBase64String(salt); // Assuming it is given as base64
    // Merge the password bytes and the salt bytes
    var mergedBytes = new byte[passwordBytes.Length + saltBytes.Length];
    Array.Copy(passwordBytes, mergedBytes, passwordBytes.Length);
    Array.Copy(saltBytes, 0, mergedBytes, passwordBytes.Length, saltBytes.Length);
    var md5 = new MD5CryptoServiceProvider();
    byte[] finalHash = md5.ComputeHash(mergedBytes);
    string final = System.Convert.ToBase64String(finalHash);        
