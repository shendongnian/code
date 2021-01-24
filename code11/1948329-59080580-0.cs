    var password = "1234567";
    var passwordBytes = Encoding.UTF8.GetBytes(password);
    
    var salt = "U2zdbUmZXCeOLs0OuS9bhg==";
    var saltBytes = Convert.FromBase64String(salt);
            
    var passwordBytesAndSaltBytes = new byte[passwordBytes.Length + saltBytes.Length];
    
    for (int i = 0; i < passwordBytes.Length; i++)
    {
        passwordBytesAndSaltBytes[i] = passwordBytes[i];
    }
    
    for (int i = 0; i < saltBytes.Length; i++)
    {
        passwordBytesAndSaltBytes[passwordBytes.Length + i] = saltBytes[i];
    }
