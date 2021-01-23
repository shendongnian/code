    string username = "myUsr";
    string password = "myPwd";
    using (var deriveBytes = new Rfc2898DeriveBytes(password, 20)) // 20-byte salt
    {
        byte[] salt = deriveBytes.Salt;
        byte[] key = deriveBytes.GetBytes(20); // 20-byte key
        string encodedSalt = Convert.ToBase64String(salt);
        string encodedKey = Convert.ToBase64String(key);
        // store encodedSalt and encodedKey in database
        // you could optionally skip the encoding and store the byte arrays directly
        db.CreateUser(username, encodedSalt, encodedKey);
    }
